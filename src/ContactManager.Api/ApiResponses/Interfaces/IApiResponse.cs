namespace ContactManager.Api.ApiResponses.Interfaces;

interface IApiResponse
{
    int StatusCode { get; }
    string? Message { get; }
    object? Data { get; }
}