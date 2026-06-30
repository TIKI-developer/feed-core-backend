namespace Feed.Application.UseCases.Users.Commands.Register;

public readonly record struct RegisterCommandResult
{
    public required string AccessToken { get; init; }
}
