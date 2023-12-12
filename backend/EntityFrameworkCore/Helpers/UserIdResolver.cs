using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace EntityFrameworkCore.Helpers;

internal interface IUserIdResolver
{
	Guid Resolve();
}

internal class UserIdResolver : IUserIdResolver
{
	public UserIdResolver(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}
	
	private readonly IHttpContextAccessor _httpContextAccessor;

	public Guid Resolve()
	{
		var requestHeaders = _httpContextAccessor.HttpContext.Request.Headers;

		requestHeaders.TryGetValue("Authorization", out var bearerToken);

		var jwtToken = bearerToken.ToString().Remove(startIndex: 0, count: 7); // removing 'Bearer' part

		var userIdClaim = new JwtSecurityTokenHandler()
			.ReadJwtToken(jwtToken)
			?.Claims
			.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

		if (userIdClaim?.Value is null)
		{
			throw new ArgumentNullException(nameof(userIdClaim));
		}

		if (!Guid.TryParse(userIdClaim.Value, out var userId))
		{
			throw new ArgumentNullException(nameof(userId));
        }

		return userId;
    }
}