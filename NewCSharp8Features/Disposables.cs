using System;
using System.Threading.Tasks;

namespace WhatsNewInCSharp8
{
	public class DisposableService
		: IDisposable
	{
		public void Dispose() => 
			Console.WriteLine($"{nameof(DisposableService)} - I am disposed.");
	}

	public ref struct DisposableRefStruct
	{
		public void Dispose() => 
			Console.WriteLine($"{nameof(DisposableRefStruct)} - I am disposed.");
	}

	public sealed class AsyncDisposableService
		: IAsyncDisposable
	{
			public async ValueTask DisposeAsync() => 
			await Console.Out.WriteLineAsync(
				$"{nameof(AsyncDisposableService)} - I am disposed.");
	}
}