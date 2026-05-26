namespace Server.Endpoints.Dtos;

internal static class Mappers
{
    public static readonly ItemMapper Item = new();

    public static readonly LiveMapper Live = new();

    public static readonly UnitMapper Unit = new();

    public static readonly UserMapper User = new();
}