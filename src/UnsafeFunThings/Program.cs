using BenchmarkDotNet.Running;
using System.Runtime.CompilerServices;
using UnsafeFunThings.FunctionPointers;
using UnsafeFunThings.RefReturns;
using UnsafeFunThings.UnsafeReflection;
using UnsafeFunThings.UsingUnsafeAs;

//BenchmarkRunner.Run<ListIndexPerformance>();
//BenchmarkRunner.Run<Calculations>();
//BenchmarkRunner.Run<CastingObjects>();
BenchmarkRunner.Run<UpdatingFields>();
//BenchmarkRunner.Run<InvokingPublicMethod>();

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