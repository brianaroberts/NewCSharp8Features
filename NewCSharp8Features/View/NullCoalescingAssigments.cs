using System;

namespace NewCSharp8Features
{
   // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/null-coalescing-assignment.md
   public static class NullCoalescingAssigments
   {
		public static void Demo()
		{
			string? GetName() => "Jason";

			string? GetNullName() => null;

			var name = GetNullName();

			// Old way:
			/*
			if (name == null)
			{
				name = GetName();
			}
			*/

			// New way:
			name ??= GetName();

			Console.WriteLine(name);
		}
   }
}
