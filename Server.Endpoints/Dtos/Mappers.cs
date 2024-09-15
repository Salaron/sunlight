namespace Server.Endpoints.Dtos;

internal static class Mappers
{
    public static readonly ItemMapper ItemMapper = new();

    public static readonly LiveMapper LiveMapper = new();

    public static readonly UnitMapper UnitMapper = new();

    public static readonly UserMapper UserMapper = new();
}