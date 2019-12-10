namespace NewCSharp8Features
{
	// https://github.com/dotnet/csharplang/blob/master/proposals/default-interface-methods.md
	public static class InterfaceMembers
	{
		public static void Demo()
		{
			// Call an interface property
			IService.StoreAValue = 100; 
			var service = new Service();
			service.DoAThing();

			IService iService = new Service();
			//Service iService = new Service();
			iService.DoAThing();
			iService.DoANewThing();
			iService.DoANewThingCallingStatic(); 


			var everythingService = new ServiceController();
			everythingService.DoAThing();
			everythingService.DoANewThing();
			// ServiceController had not implemented DoANewThinkCallingStatic
			//everythingService.DoANewThingCallingStatic();
		}
	}
}
