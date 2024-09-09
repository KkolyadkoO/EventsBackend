namespace EventApp.Controllers;

public record UserLoginRequest
(
    string Username,
    string Password
);