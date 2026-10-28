using BenchmarkDotNet.Attributes;
using System.Reflection;
using System.Security.Cryptography;

namespace UnsafeFunThings.UnsafeReflection;

[MemoryDiagnoser]
public class InvokingPublicMethod
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	private Content content;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

	[GlobalSetup]
	public void Setup()
	{
		var id = RandomNumberGenerator.GetInt32(10_000);
		var index = Guid.NewGuid();
		this.content = new Content();
		ContentUnsafeAccessors.GetIdField(this.content) = id;
		ContentUnsafeAccessors.GetIndexField(this.content) = index;
	}

	[Benchmark(Baseline = true)]
	public int InvokeDirectly() => 
		this.content.Generate();

	[Benchmark]
	public int InvokeUsingReflection() => 
		(int)this.content.GetType().GetMethod("Generate", BindingFlags.Instance | BindingFlags.Public)!.Invoke(this.content, [])!;

	[Benchmark]
	public int InvokeUsingUnsafeAccessor() =>
		ContentUnsafeAccessors.GenerateMethod(this.content);
}