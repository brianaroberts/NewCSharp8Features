using System;
using System.Buffers;
using System.Text;
using System.Text.Json;
using System.IO;

namespace NewCSharp8Features
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

		public static void DemoJsonReader()
		{
			Console.WriteLine("================= Utf8JsonReader Sample ================= ");
			var jsonBytes = File.ReadAllBytes(".\\assets\\reader.json");
			var jsonSpan = jsonBytes.AsSpan();
			var json = new Utf8JsonReader(jsonSpan);

			while (json.Read())
			{
				Console.WriteLine(json.TokenType switch
				{
					JsonTokenType.StartObject => "START OBJECT",
					JsonTokenType.EndObject => "END OBJECT",
					JsonTokenType.StartArray => "START ARRAY",
					JsonTokenType.EndArray => "END ARRAY",
					JsonTokenType.PropertyName => $"PROPERTY: {json.GetString()}",
					JsonTokenType.Comment => $"COMMENT: {json.GetString()}",
					JsonTokenType.String => $"STRING: {json.GetString()}",
					JsonTokenType.Number => $"NUMBER: {json.GetInt32()}",
					JsonTokenType.True => $"BOOL: {json.GetBoolean()}",
					JsonTokenType.False => $"BOOL: {json.GetBoolean()}",
					JsonTokenType.Null => $"NULL",
					_ => $"**UNHANDLED TOKEN: {json.TokenType}"
				});
			}

			Console.WriteLine("================= ================= ================= ");
		}

		public static void DemoJsonSerializer()
		{
			Console.WriteLine("================= Utf8JsonSerializer Sample ================= ");

			// By Default Pascal case is looked for inside the json file. We can override 
			//	that with options though. 
			var options = new JsonSerializerOptions()
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase				
			};

			var readBytes = File.ReadAllBytes(".\\assets\\reader.json");
			var json = JsonSerializer.Deserialize<Team>(readBytes, options);
			//var json = JsonSerializer.Deserialize<Team>(readBytes, options);

			Console.WriteLine($"Team Name: {json.TeamName}");
			Console.WriteLine($"Year Founded: {json.YearCreated}");
			Console.WriteLine($"Number of Superbowls won: {json.NumberOfSuperbowls}");

			Console.WriteLine("Let's just write everything out: ");
			Console.WriteLine(JsonSerializer.Serialize(json, options));

			Console.WriteLine("================= ================= ================= ");
		}
	}
}
