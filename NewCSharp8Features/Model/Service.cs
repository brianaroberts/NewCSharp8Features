using System;

namespace WhatsNewInCSharp8
{
   public sealed class Service
			: IService
   {
	  public void DoAThing() => Console.WriteLine("I did something.");
   }
}
