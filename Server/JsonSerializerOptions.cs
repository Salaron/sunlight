using System.Text.Json;
using SunLight.Dtos;

namespace SunLight;

internal static class JsonSerializerDefaultOptions
{

    public static JsonSerializerOptions GetOptions()
    {
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            Converters = { new DateTimeConverter() }
        };

        return jsonOptions;
    }
}