using ContactManager.Api.ApiResponses.Interfaces;
using ContactManager.Api.ApiResponses.Shared;

namespace ContactManager.Api.ApiResponses;

public class ApiOk : BaseApiResponse, IApiResponse
{
    public new int StatusCode { get; } = 200;
    public ApiOk(string? message = null, object? data = null) : base(message, data) { }
}