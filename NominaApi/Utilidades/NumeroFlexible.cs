using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NominaApi.Utilidades;

// Angular manda lo que hay en las cajas de texto como texto: "7", "9500" o "" (vacío).
// Esto convierte ese texto a número; si la caja está vacía, lo deja como null.
public class NumeroFlexible<T> : JsonConverter<T?> where T : struct
{
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;
        string texto = reader.TokenType == JsonTokenType.String
            ? reader.GetString() ?? ""
            : Convert.ToString(JsonDocument.ParseValue(ref reader).RootElement.GetRawText(), CultureInfo.InvariantCulture);
        if (string.IsNullOrWhiteSpace(texto)) return null;
        return (T)Convert.ChangeType(texto.Trim(), typeof(T), CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
    {
        if (value == null) writer.WriteNullValue();
        else JsonSerializer.Serialize(writer, value.Value, options);
    }
}

// Lo mismo para los ids (int sin null): vacío = 0
public class EnteroFlexible : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number) return reader.GetInt32();
        if (reader.TokenType == JsonTokenType.Null) return 0;
        var texto = reader.GetString();
        return string.IsNullOrWhiteSpace(texto) ? 0 : int.Parse(texto.Trim(), CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        => writer.WriteNumberValue(value);
}

// Y para los textos (CP, RFC...) por si llegan como número
public class TextoFlexible : JsonConverter<string>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null) return null;
        if (reader.TokenType == JsonTokenType.String) return reader.GetString();
        return JsonDocument.ParseValue(ref reader).RootElement.GetRawText();
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        => writer.WriteStringValue(value);
}
