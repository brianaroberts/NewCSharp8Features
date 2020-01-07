using System;

namespace NewCSharp8Features
{
	// https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/patterns.md
	static class Patterns
	{
		private static IAnimal GetAnimal() 
		{
			var randomAnimal = new Random().Next(0, 3);

			return randomAnimal == 0 ? new Dog()
			: randomAnimal == 1 ? new Robot() { Name = "Bobby Flay"} : (IAnimal)(new Cat());
		}
		public static void Demo()
		{
			var animal = GetAnimal();
			var mood = new Random().Next(0, 2);

			// Switch Pattern, Note the variable is reversed
			Console.WriteLine(animal switch
			{
				// NOTE: There is no 'case:' and the bodies have been replaced with expressions instead of statements.
				// Property Pattern
				//IAnimal r when r.Temperment == eTemperment.AI => "I am a robot",
				{ Temperment: eTemperment.AI, Name: var name }  => $"I am a robot named {name}",
				// Recursive Pattern
				Dog(var food, var weight) => $"Dogs weigh alot ({weight}) cause they eat lots of {food}.",
				// Discard used
				Cat _ when mood == 0 => "Meow",
				Cat _ when mood != 0 => "Hiss",
				// Discard pattern serves as the "default" keyword
				_ => "These are not the animals you are looking for!"
			});
		}

		private static IResult<int> Divide(int x, int y)
		{
			if (y != 0)
			{
				return new Result<int>(x / y);
			}
			else
			{
				return new Error<int>("Can't divide by zero.");
			}
		}

		public static void DemoWithErrors()
		{
			_ = Divide(6, 3) switch
			{
				Result<int> result => Results.Complete(() => { Console.WriteLine($"Result: {result.Value}"); }),
				Error<int> error => Results.Complete(() => { Console.WriteLine($"Error: {error.Message}"); }),
				_ => None.Instance
			};

			_ = Divide(6, 0) switch
			{
				Result<int> result => Results.Complete(() => { Console.WriteLine($"Result: {result.Value}"); }),
				Error<int> error => Results.Complete(() => { Console.WriteLine($"Error: {error.Message}"); }),
				_ => None.Instance
			};
		}
	}
}
