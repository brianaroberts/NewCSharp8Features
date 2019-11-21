using System;

namespace WhatsNewInCSharp8
{
   public sealed class ServiceController
			: IService
   {
	  public void DoAThing() => Console.WriteLine("I did something.");
	  public void DoANewThing() => Console.WriteLine("I did my own thing");
   }
}
