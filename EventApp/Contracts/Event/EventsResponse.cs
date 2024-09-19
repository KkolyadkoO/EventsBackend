namespace EventApp.Contracts;

public record EventsResponse(
      Guid Id,
      string Title,
      string Description,
      DateTime Date,
      string Location,
      Guid CategoryId,
      int MaxNumberOfMembers,
      int NumberOfMembers,
      string ImageUrl
  );