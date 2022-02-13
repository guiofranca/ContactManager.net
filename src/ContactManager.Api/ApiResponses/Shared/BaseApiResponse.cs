using ContactManager.Api.ApiResponses.Interfaces;

namespace ContactManager.Api.ApiResponses.Shared;

public abstract class BaseApiResponse : IApiResponse
{
    public int StatusCode { get; private set; }
    public string? Message { get; }
    public object? Data { get; }

    public BaseApiResponse(string? message = null, object? data = null)
    {
        Message = message;
        Data = data;
    }
}