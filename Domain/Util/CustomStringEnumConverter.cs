using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Domain.Util
{
    public class CustomStringEnumConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
            (JsonConverter)Activator.CreateInstance(typeof(CustomConverter<>).MakeGenericType(typeToConvert))!;

        class CustomConverter<T> : JsonConverter<T> where T : struct, Enum
        {
            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
                throw new NotImplementedException();

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                Type type = value.GetType() as Type;

                if (!type.IsEnum) throw new InvalidOperationException("Only type Enum is supported");
                foreach (var field in type.GetFields())
                {
                    if (field.Name == value.ToString())
                    {
                        var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                        writer.WriteStringValue(attribute != null ? attribute.Description : field.Name);

                        return;
                    }
                }
                throw new ArgumentException("Enum not found");
            }
        }
    }
}