using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;

namespace UnsafeFunThings.FunctionPointers;

public class Calculations
{
	private int first;
	private int second;


	[GlobalSetup]
	public void Setup()
	{
		this.first = RandomNumberGenerator.GetInt32(1_000);
		this.second = RandomNumberGenerator.GetInt32(1_000);
	}

	private static int CalculateViaDelegate(Func<int, int, int> calculator, int first, int second) =>
		calculator(first, second);

	private static unsafe int CalculateViaFunctionPointer(delegate*<int, int, int> calculator, int first, int second) =>
		calculator(first, second);

	private static int Calculator(int first, int second) => first + second;

	[Benchmark(Baseline = true)]
	public int DelegateMethod() => Calculations.CalculateViaDelegate(Calculations.Calculator, this.first, this.second);

	[Benchmark]
	public int FunctionPointerMethod()
	{
		unsafe
		{
			return Calculations.CalculateViaFunctionPointer(&Calculations.Calculator, this.first, this.second);
		}
	}
}