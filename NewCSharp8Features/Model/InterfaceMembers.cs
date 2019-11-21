namespace WhatsNewInCSharp8
{
   // https://github.com/dotnet/csharplang/blob/master/proposals/default-interface-methods.md
   public static class InterfaceMembers
   {
	  public static void Demo()
	  {
		 var service = new Service();
		 service.DoAThing();

		 IService iService = new Service();
		 iService.DoAThing();
		 iService.DoANewThing();

		 var everythingService = new ServiceController();
		 everythingService.DoAThing();

		 IService iEverythingService = new ServiceController();
		 iEverythingService.DoAThing();
		 iEverythingService.DoANewThing();
	  }
   }
}
