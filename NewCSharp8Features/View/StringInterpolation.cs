using System;

namespace NewCSharp8Features
{
	// https://github.com/dotnet/csharplang/issues/1630
	public static class StringInterpolation
	{
		public static void Demo()
		{
			var value = new Random().Next();
			var currentWay = $@"Here is the current way: {value}";
			var newWay = @$"Here is the new way: {value}";

			Console.WriteLine(currentWay);
			Console.WriteLine(newWay);
		}
	}
}
