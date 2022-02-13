using ContactManager.Api.ApiResponses.Interfaces;
using ContactManager.Api.ApiResponses.Shared;

namespace ContactManager.Api.ApiResponses;

public class ApiUnprocessableEntity : BaseApiResponse, IApiResponse
{
    public new int StatusCode { get; } = 422;
    public ApiUnprocessableEntity(string? message = null, object? data = null) : base(message, data) { }
}