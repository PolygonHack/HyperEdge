using System;
using Newtonsoft.Json;


namespace HyperEdge.Shared.Utils
{
    public class UlidConverter : JsonConverter<Ulid>
    {
        public override void WriteJson(JsonWriter writer, Ulid value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override Ulid ReadJson(JsonReader reader, Type objectType, Ulid existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string s = (string)reader.Value;
            return Ulid.Parse(s);
        }
    }
}

