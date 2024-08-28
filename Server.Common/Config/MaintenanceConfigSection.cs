namespace Server.Common.Config;

public record MaintenanceSchedule
{
    public DateTime Start { get; init; }
    public DateTime End { get; init; }
    public string? Message { get; init; }
}

public record MaintenanceConfigSection
{
    public bool IsForced { get; init; }
    public required List<MaintenanceSchedule> Schedule { get; init; } = [];
}