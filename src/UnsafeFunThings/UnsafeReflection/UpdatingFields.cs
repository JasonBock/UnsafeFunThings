using BenchmarkDotNet.Attributes;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace UnsafeFunThings.UnsafeReflection;

// If you don't need to modify the field value,
// you can remove the "ref" keyword.
public static class ContentUnsafeAccessors
{
	[UnsafeAccessor(UnsafeAccessorKind.Method, Name = "Compute")]
	public static extern int ComputeMethod(Content content);

	[UnsafeAccessor(UnsafeAccessorKind.Field, Name = "id")]
	public static extern ref int GetIdField(Content content);

	[UnsafeAccessor(UnsafeAccessorKind.Field, Name = "index")]
	public static extern ref Guid GetIndexField(Content content);
}

[MemoryDiagnoser]
public class UpdatingFields
{
	private int id;
	private Guid index;

	[GlobalSetup]
	public void Setup()
	{
		this.id = RandomNumberGenerator.GetInt32(10_000);
		this.index = Guid.NewGuid();
	}

	[Benchmark(Baseline = true)]
	public int SetFieldsAndComputeViaReflection()
	{
		var content = new Content();
		var contentType = content.GetType();
		var contentIdField = contentType.GetField("id", BindingFlags.Instance | BindingFlags.NonPublic)!;
		var contentIndexField = contentType.GetField("index", BindingFlags.Instance | BindingFlags.NonPublic)!;
		contentIdField.SetValue(content, this.id);
		contentIndexField.SetValue(content, this.index);

		return (int)contentType.GetMethod("Compute", BindingFlags.Instance | BindingFlags.NonPublic)!.Invoke(content, [])!;
	}

	[Benchmark]
	public int SetFieldsAndComputeViaUnsafeAccessors()
	{
		var content = new Content();
		ContentUnsafeAccessors.GetIdField(content) = this.id;
		ContentUnsafeAccessors.GetIndexField(content) = this.index;
		return ContentUnsafeAccessors.ComputeMethod(content);
	}
}
