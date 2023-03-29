using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Trek12_API.JsonConverter
{
	public class ReadOnlyDictionnaryConverter<TKey,TValue>: JsonConverter<ReadOnlyDictionary<TKey,TValue>>
	{
        public override ReadOnlyDictionary<TKey, TValue>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Dictionary<TKey, TValue> dictionary = JsonSerializer.Deserialize<Dictionary<TKey, TValue>>(ref reader, options);
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        public override void Write(Utf8JsonWriter writer, ReadOnlyDictionary<TKey, TValue> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.ToDictionary(kv => kv.Key, kv => kv.Value),options);
        }

    }
}

