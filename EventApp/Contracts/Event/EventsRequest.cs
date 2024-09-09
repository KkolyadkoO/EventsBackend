namespace EventApp.Contracts;

public record EventsRequest(
    string Title,
    string Description,
    DateTime Date,
    string Location,
    int maxNumberOfMembers,
    Guid CategoryId,
    string ImageUrl
    );