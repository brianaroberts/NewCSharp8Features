using System;

namespace WhatsNewInCSharp8
{
   // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/using.md
   public static class Using
   {
	  public static void Demo()
	  {
		 using var _ = new DisposableService();
		 Console.WriteLine($"I am within the disposable scope of {nameof(DisposableService)}");
		 Console.WriteLine($"I am still within the disposable scope of {nameof(DisposableService)}");

		 using (var refStruct = new DisposableRefStruct())
		 {
			Console.WriteLine($"I am within the disposable scope of {nameof(DisposableRefStruct)}");
			Console.WriteLine($"I am still within the disposable scope of {nameof(DisposableRefStruct)}");
		 }
	  }

	  public static void EnhancedDemo()
	  {
		 using var _ = new DisposableService();
		 Console.WriteLine($"I am within the disposable scope of {nameof(DisposableService)}");
		 Console.WriteLine($"I am still within the disposable scope of {nameof(DisposableService)}");

		 using (var refStruct = new DisposableRefStruct())
		 {
			Console.WriteLine($"I am within the disposable scope of {nameof(DisposableRefStruct)}");
			Console.WriteLine($"I am still within the disposable scope of {nameof(DisposableRefStruct)}");
		 }
	  }
   }
}
