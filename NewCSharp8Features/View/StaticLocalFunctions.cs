using System;

namespace NewCSharp8Features
{
	// https://github.com/dotnet/csharplang/issues/1565
	public static class StaticLocalFunctions
	{
		public static void Demo()
		{
			var value = new Random().Next();

			int CanCaptureLocal() => value;

			static int CannotCaptureLocal() => new Random().Next();

			Console.WriteLine($"{nameof(value)} - {CanCaptureLocal()}");
			Console.WriteLine($"{nameof(CanCaptureLocal)} - {CanCaptureLocal()}");
			Console.WriteLine($"{nameof(CannotCaptureLocal)} - {CannotCaptureLocal()}");
		}
	}
}
