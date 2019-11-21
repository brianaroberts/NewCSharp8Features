using System;
using System.Threading.Tasks;

namespace WhatsNewInCSharp8
{
   public class Program
   {
	  static void Main()
	  {
		 Patterns.Demo();
		 Patterns.DemoWithErrors();
		 NullRefs.Demo();
		 NullRefs.DemoReflection();
		 Using.Demo();
		 Using.EnhancedDemo();		 
		 RangesAndIndexes.Demo();
		 InterfaceMembers.Demo();
		 NullCoalescingAssigments.Demo();
		 StaticLocalFunctions.Demo();
		 StringInterpolation.Demo();
	  }

	  //static async Task Main() =>
	  // await Program.AsynchronousDisposableDemo();
	  ////await Program.AsynchronousStreamsDemo();


	  // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/async-streams.md
	  private static async Task AsynchronousDisposableDemo()
	  {
		 await using (var _ = new AsyncDisposableService())
			await Console.Out.WriteLineAsync(
				$"I am within the disposable scope of {nameof(AsyncDisposableService)}");
	  }

	  // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/async-streams.md
	  private static async Task AsynchronousStreamsDemo()
	  {
		 await foreach (var value in new AsynchronousRandom(10))
		 {
			await Console.Out.WriteLineAsync(value.ToString());
		 }
	  }

   }
}