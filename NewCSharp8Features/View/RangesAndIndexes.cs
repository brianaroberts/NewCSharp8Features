﻿using System;

namespace NewCSharp8Features
{
	public static class RangesAndIndexes
	{
		// https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/ranges.md
		public static void Demo()
		{
			var values = new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
			var aRange = 2..5; // [2] up to and including [4]

			Console.WriteLine($"[..] Everything: {string.Join(", ", values[..])}");
			Console.WriteLine($"[2..5] From the 2nd to the 5th (exclusive): {string.Join(", ", values[aRange])}");
			Console.WriteLine($"[3..] Everything after the 3rd (including the 3rd): {string.Join(", ", values[3..])}");

			aRange = ..^1;  // NOte here that ^0 would be the same as [.Length] so it is invalid. 
			Console.WriteLine($"[..^1] Everything except the last: {string.Join(", ", values[aRange])}");

			// Let's use as Span to make sure we don't make a copy...More effecient. 
			Console.WriteLine($"[^1] Just the last: {string.Join(", ", values.AsSpan()[^1])}");
			Console.WriteLine($"[^2] Just the second to the last: {string.Join(", ", values[^2])}");
			Console.WriteLine($"[^3] Just the third to the last: {string.Join(", ", values[^3])}");

			// Do you understand why this is true?
			Console.WriteLine($"This will show you everything: {string.Join(", ", values[0..^0])}");

			var range = new Range(2, 5);
			var index = new Index(3, true);
			Console.WriteLine($"From the 2nd to the 5th (exclusive) with a range: {string.Join(", ", values[range])}");
			Console.WriteLine($"Just the third to the last with an index: {string.Join(", ", values[index])}");

			// Let's prove that we are getting a copy
			var rangeCopy = values[0..3];
			rangeCopy[0] = 22;
			Console.WriteLine($"Changing rangeCopy[0]: {values[0]}");

			// Lets prove we can create a reference
			var rangeSlice = values.AsSpan()[0..3];
			rangeSlice[0] = 22;
			Console.WriteLine($"Changing rangeSlice[0]: {values[0]}");

		}
	}
}
