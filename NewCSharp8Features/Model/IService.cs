using System;

namespace WhatsNewInCSharp8
{
   public interface IService
   {
	  private static void WriteNewThing() => Console.WriteLine("I did a new thing.");
	  void DoAThing();
	  void DoANewThing() => IService.WriteNewThing();
   }
}
