using System.Text.Json;
using SunLight.Infrastructure.Json;

namespace SunLight;

internal static class JsonSerializerDefaultOptions
{

    public static JsonSerializerOptions GetOptions()
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Converters = { new DateTimeJsonConverter() }
        };

        return jsonOptions;
    }
}