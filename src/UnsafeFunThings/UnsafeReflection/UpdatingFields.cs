using BenchmarkDotNet.Attributes;
using SaferAccessors;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using UnsafeFunThings.UnsafeReflection;

[assembly: UnsafeAccessorMap(typeof(Content))]

namespace UnsafeFunThings.UnsafeReflection;

[MemoryDiagnoser]
public class UpdatingFields
{
	private int id;
	private Guid index;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	private FieldInfo cachedContentIdField;
	private FieldInfo cachedContentIndexField;
	private MethodInfo cachedContentComputeMethod;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

	[GlobalSetup]
	public void Setup()
	{
		this.id = RandomNumberGenerator.GetInt32(10_000);
		this.index = Guid.NewGuid();

		var contentType = typeof(Content);
		this.cachedContentIdField = contentType.GetField("id", BindingFlags.Instance | BindingFlags.NonPublic)!;
		this.cachedContentIndexField = contentType.GetField("index", BindingFlags.Instance | BindingFlags.NonPublic)!;
		this.cachedContentComputeMethod = contentType.GetMethod("Compute", BindingFlags.Instance | BindingFlags.NonPublic)!;
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
	public int SetFieldsAndComputeViaCachedReflection()
	{
		var content = new Content();
		this.cachedContentIdField.SetValue(content, this.id);
		this.cachedContentIndexField.SetValue(content, this.index);

		return (int)this.cachedContentComputeMethod.Invoke(content, [])!;
	}

	[Benchmark]
	public int SetFieldsAndComputeViaUnsafeAccessors()
	{
		var content = new Content();
		ContentUnsafeAccessors.GetIdField(content) = this.id;
		ContentUnsafeAccessors.GetIndexField(content) = this.index;

		return ContentUnsafeAccessors.ComputeMethod(content);
	}

	[Benchmark]
	public int SetFieldsAndComputeViaSaferAccessors()
	{
		var content = new Content
		{
			id = this.id,
			index = this.index
		};

		return content.Compute();
	}
}