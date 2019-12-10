using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewCSharp8Features
{
	public class Program
	{
		static int ThreadId => Thread.CurrentThread.ManagedThreadId;

		//static void Main()
		//{
		//	//Patterns.Demo();
		//	//Patterns.DemoWithErrors();

		//	//NullRefs.Demo();
		//	//NullRefs.DemoReflection();

		//	//Using.Demo();
		//	//Using.EnhancedDemo();

		//	//RangesAndIndexes.Demo();

		//	//InterfaceMembers.Demo();

		//	//NullCoalescingAssigments.Demo();

		//	//StaticLocalFunctions.Demo();

		//	//StringInterpolation.Demo();

		//	//CoreJson.DemoJsonReader();
		//	//CoreJson.DemoJsonWriter();
		//	//CoreJson.DemoJsonSerializer();

		//	Console.WriteLine("Press any key to exit"); 
		//	Console.ReadKey(); 
		//}

		static async Task Main() {
			await Program.AsyncDisposableDemo();
			await Program.AsyncStreamsDemo();
		}



	// https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/async-streams.md
	private static async Task AsyncDisposableDemo()
		{
			await using (var _ = new AsyncDisposableService())
				await Console.Out.WriteLineAsync(
					$"I am within the disposable scope of {nameof(AsyncDisposableService)}");
		}

		// https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/async-streams.md
		private static async Task AsyncStreamsDemo()
		{
			Console.WriteLine($"Enumerating Random Number Generator on thread {ThreadId}...");

			await foreach (var value in new AsynchronousRandom(100))
			{
				await Console.Out.WriteLineAsync($"[{ThreadId}]:{value.ToString()}");
			}
		}

	}
}