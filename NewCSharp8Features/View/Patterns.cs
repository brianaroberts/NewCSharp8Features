using System;

namespace WhatsNewInCSharp8
{
   // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/patterns.md
   static class Patterns
   {
	  private static IAnimal GetAnimal() =>
		  new Random().Next(0, 2) == 0 ? new Dog() : (IAnimal)(new Cat());
	  public static void Demo()
	  {
		 var animal = GetAnimal();
		 var mood = new Random().Next(0, 2);

		 Console.WriteLine(animal switch
		 {
			Dog _ => "Woof",
			Cat _ when mood == 0 => "Meow",
			_ => "Hiss"
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
