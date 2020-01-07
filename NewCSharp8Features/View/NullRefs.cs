using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NewCSharp8Features
{
   // https://github.com/dotnet/csharplang/blob/master/proposals/csharp-8.0/nullable-reference-types.md
   public static class NullRefs
   {
	  public static void Demo()
	  {
		 var person = new Person { Id = Guid.NewGuid()/*, Name = "Batman"*/ };

			Console.WriteLine($"{person.Name?.Length}, {person.Id}");
		}

		public static void ComplexParameter(
		Dictionary<List<string>, KeyValuePair<Guid, byte[]?>> value)
		{ }

		public static void DemoReflection()
		{
			Console.WriteLine($"typeof(string).FullName - {typeof(string).FullName}");
			//Console.WriteLine($"typeof(string?).FullName - {typeof(string?).FullName}");

			var parameter = typeof(NullRefs).GetMethod(nameof(NullRefs.ComplexParameter))!.GetParameters()[0];

			Console.WriteLine(parameter.ParameterType.FullName);

			var nullableAttributeFlags =
			(from attribute in parameter.GetCustomAttributesData()
			 let attributeType = attribute.AttributeType
			 where attributeType.Name == "NullableAttribute" &&
				 attributeType.Namespace == "System.Runtime.CompilerServices" &&
				 attribute.ConstructorArguments.Count > 0
			 let nullableCtor = attribute.ConstructorArguments[0]
			 select nullableCtor.ArgumentType.IsArray switch
			 {
				 true => ((IList<CustomAttributeTypedArgument>)nullableCtor.Value!).Select(_ => (byte)_.Value!).ToArray(),
				 _ => new byte[] { (byte)nullableCtor.Value! }
			 }).First();

			Console.WriteLine($"{nameof(nullableAttributeFlags)} - {string.Join(", ", nullableAttributeFlags)}");
		}
	}
}
