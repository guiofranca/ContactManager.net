using ContactManager.Api.ApiResponses.Interfaces;
using ContactManager.Api.ApiResponses.Shared;

namespace ContactManager.Api.ApiResponses;

public class ApiCreated : BaseApiResponse, IApiResponse
{
    public new int StatusCode { get; } = 201;
    public ApiCreated(string? message = null, object? data = null) : base(message, data) { }
}