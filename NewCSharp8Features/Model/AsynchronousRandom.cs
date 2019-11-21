using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WhatsNewInCSharp8
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
				yield return random.Next();
				await Task.Delay(random.Next(100, 1000));
			}
		}
	}
}