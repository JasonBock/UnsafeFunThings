namespace UnsafeFunThings.UnsafeReflection;

public sealed class Content
{
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable CA1823 // Avoid unused private fields
#pragma warning disable CS0649
	private int id;
	private Guid index;

	private int Compute() => this.id ^ this.index.GetHashCode();
}