using System.Runtime.CompilerServices;

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
