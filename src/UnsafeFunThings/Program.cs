using BenchmarkDotNet.Running;
using UnsafeFunThings.RefReturns;
using UnsafeFunThings.UsingUnsafeAs;

BenchmarkRunner.Run<ListIndexPerformance>();
//BenchmarkRunner.Run<CastingObjects>();

/*
object target = new TargetType();

try
{
	var stringTarget = ((string)target)!;
	Console.WriteLine(stringTarget.GetType().FullName);
	Console.WriteLine(stringTarget.Length);
}
catch (InvalidCastException e)
{
	Console.WriteLine($"Cast exception: {e.Message}");
}

Console.WriteLine();

try
{
	var stringTarget = Unsafe.As<string>(target);
	Console.WriteLine(stringTarget.GetType().FullName);
	Console.WriteLine(stringTarget.Length);
}
catch (InvalidCastException e)
{
	Console.WriteLine($"Unsafe.As() exception: {e.Message}");
} 
*/