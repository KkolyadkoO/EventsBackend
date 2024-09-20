namespace EventApp.Contracts;

public record EventFilterRequest(
    string? Title = null,
    string? Location = null,
    DateTime? StartDate = null,
    DateTime? EndDate = null,
    Guid? Category = null,
    int? page = null,
    int? pageSize = null
);