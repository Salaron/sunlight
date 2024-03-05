using System.Text.Json;

namespace Server.Common.Json;

public static class JsonSerializerDefaultOptions
{
    public static JsonSerializerOptions GetOptions()
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Converters = { new DateTimeJsonConverter() },
        };

        return jsonOptions;
    }
}