using Kazue.Domain.Interfaces.Security.Token;

namespace Kazue.Api.Token;

/// <summary>
/// Middleware responsible Token Provider
/// </summary>
/// <param name="httpContextAccessor"></param>
public class HttpContextTokenValue(IHttpContextAccessor httpContextAccessor) : ITokenProvider
{
    private readonly IHttpContextAccessor _contextAccessor = httpContextAccessor;

    /// <summary>
    /// Process token request
    /// </summary>
    /// <returns></returns>
    public string TokenOnRequest()
    {
        var authorization = _contextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

        return authorization["Bearer ".Length..].Trim();
    }
}
