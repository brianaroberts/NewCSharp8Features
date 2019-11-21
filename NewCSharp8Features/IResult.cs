using System;

namespace WhatsNewInCSharp8
{
	public sealed class None
	{
		private static Lazy<None> instance = 
			new Lazy<None>(() => new None());

		private None() { }

		public static None Instance => None.instance.Value;
	}

	public static class Results
	{
		public static None Complete(Action action)
		{
			action();
			return None.Instance;
		}
	}

	public interface IResult { }

	public interface IResult<T>
		: IResult
	{
		T Value { get; }
	}

	public sealed class Result : IResult { }

	public sealed class Error : IResult { }

	public sealed class Result<T> : IResult<T>
	{
		public Result(T value) => this.Value = value;
		public T Value { get; }
	}

	public sealed class Error<T> : IResult<T>
	{
		public Error(string message) =>
			this.Message = message ?? throw new ArgumentNullException(nameof(message));
		public string Message { get; }
		public T Value => throw new NotSupportedException();
	}
}