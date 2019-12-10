using System;

namespace NewCSharp8Features
{
   public sealed class Service
			: IService
   {
	  public void DoAThing() => Console.WriteLine("I did something.");
   }
}
