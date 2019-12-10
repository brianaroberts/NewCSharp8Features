using System;

namespace NewCSharp8Features
{
   public interface IService
   {
		private static void WriteNewThing(string message) => Console.WriteLine(message);
		public static int StoreAValue; 
		void DoAThing();
		void DoANewThing() => Console.WriteLine("I did a new thing");
		void DoANewThingCallingStatic() => IService.WriteNewThing("I did a new thing calling static");
	}
}
