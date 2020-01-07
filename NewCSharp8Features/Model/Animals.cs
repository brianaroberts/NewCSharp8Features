namespace NewCSharp8Features
{
	public enum eTemperment { 
		Friendly, 
		Sneeky,
		AI
	}
	public interface IAnimal {
		public eTemperment Temperment { get; }
		public string Name { get; set; }
	}

	public abstract class Animal : IAnimal
	{
		public int Weight;
		public string Food = "Unknown";
		public eTemperment Temperment { get; set; }
		public string Name { get; set; } = "Animal"; 

		public void Deconstruct(out string food, out int weight) => (food, weight) = (Food, Weight); 
	}

	public sealed class Dog : Animal
	{		

		public Dog()
		{
			Temperment = eTemperment.Friendly;
			Food = "Kibble";
			Weight = 25;
			Name = "Just a Dog"; 
		}
	}

	public sealed class Cat : Animal {

		public Cat()
		{
			Temperment = eTemperment.Sneeky;
			Food = "Milk";
			Weight = 5;
			Name = "Just a Cat";
		}
	}

	public sealed class Robot : Animal
	{
		public Robot()
		{
			Temperment = eTemperment.AI;
			Food = "Electricity";
			Weight = 100;
			Name = "Just a robot";
		}
	}

}
