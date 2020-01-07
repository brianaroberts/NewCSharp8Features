using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewCSharp8Features
{
	public class Program
	{
		static int ThreadId => Thread.CurrentThread.ManagedThreadId;

		static void Main()
		{
			//NullRefs.Demo();
			//NullRefs.DemoReflection();

			//Patterns.Demo(); Patterns.Demo(); Patterns.Demo(); Patterns.Demo();
			//Patterns.DemoWithErrors();

			//RangesAndIndexes.Demo();

			//STREAMS BELOW

			//CoreJson.DemoJsonReader();
			//CoreJson.DemoJsonWriter();
			//CoreJson.DemoJsonSerializer();

			//Using.Demo();
			//Using.EnhancedDemo();

			//InterfaceMembers.Demo();

			//NullCoalescingAssigments.Demo();

			//StaticLocalFunctions.Demo();

			//StringInterpolation.Demo();

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}

		//static async Task Main()
		//{
		//	await Program.AsyncDisposableDemo();
		//	await Program.AsyncStreamsDemo();

		//	Console.WriteLine("Press any key to exit");
		//	Console.ReadKey();
		//}

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

			await foreach (var value in new AsynchronousRandom(10))
			{
				await Console.Out.WriteLineAsync($"[{ThreadId}]:{value.ToString()}");
				await Task.Delay(100);
			}
		}

	}
}