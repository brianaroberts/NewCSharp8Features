using System;
using System.Buffers;
using System.Text;
using System.Text.Json;

namespace WhatsNewInCSharp8
{
	public static class CoreJson
	{
		public static void DemoJsonWriter()
		{
			Console.WriteLine("================= Utf8JsonWriter Sample ================= ");

			var options = new JsonWriterOptions
			{
				Indented = true
			};

			var buffer = new ArrayBufferWriter<byte>();
			using var json = new Utf8JsonWriter(buffer, options);

			json.WriteStartObject();
			json.WritePropertyName("company");
			json.WriteStringValue("Acme");

			json.WriteString("language", "C#");

			json.WriteStartObject("author");

			json.WriteString("firstName", "Bugs");
			json.WriteString("lastName", "Bunny");

			json.WriteEndObject();
			json.WriteEndObject();

			json.Flush();

			var output = buffer.WrittenSpan.ToArray();
			var ourJson = Encoding.UTF8.GetString(output);
			Console.WriteLine(ourJson);
			Console.WriteLine("================= ================= ================= ");
		}

	}
}
