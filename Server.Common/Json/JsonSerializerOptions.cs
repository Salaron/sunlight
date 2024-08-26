using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server.Common.Json;

public static class JsonSerializerDefaultOptions
{
    public static JsonSerializerOptions GetOptions()
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Converters = { new DateTimeJsonConverter() },
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        return jsonOptions;
    }
}