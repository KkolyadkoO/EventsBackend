namespace EventApp.Contracts;

public record EventsResponse(
      Guid Id,
      string Title,
      string Description,
      DateTime Date,
      string Location,
      Guid CategoryId,
      string ImageUrl
  );