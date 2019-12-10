using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NewCSharp8Features
{
	public sealed class AsynchronousRandom 
		: IAsyncEnumerable<int>
	{
		private readonly uint count;

		public AsynchronousRandom(uint count) => this.count = count;

		public async IAsyncEnumerator<int> GetAsyncEnumerator(CancellationToken cancellationToken = default)
		{
			var random = new Random();

			for(var i = 0; i < this.count; i++)
			{				
				//await Task.Delay(random.Next(10, 200));
				await Task.Delay(1000);
				yield return random.Next();
			}
		}
	}
}