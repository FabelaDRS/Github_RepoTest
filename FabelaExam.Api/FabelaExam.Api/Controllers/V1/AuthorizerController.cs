using FabelaExam.Api.Helpers;
using FabelaExam.Business.Interfaces;
using FabelaExam.Models.Authorizer;
using FabelaExam.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace FabelaExam.Api.Controllers.V1
{
    
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthorizerController : ControllerBase
    {
        internal readonly IAuthorizer _authorizer;
        public AuthorizerController(IAuthorizer authorizer)
        {
            _authorizer = authorizer;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> GetAuthorizer([FromBody] AuthorizationRequest request)
        {
            Response<GetAuthorizationResponse>? response = await _authorizer.GetTokenAsync(request);
            return ApiHelpers.MappingResponse(response, "1.0");
        }

        [HttpPost]
        [Route("refreshToken")]
        public async Task<IActionResult> GetRefreshAuthorizer([FromBody] RefreshTokenRequest request)
        {
            var _tokenHandler = new JwtSecurityTokenHandler();
            var _tokenExpired = _tokenHandler.ReadJwtToken(request.ExpiredToken);

            if (_tokenExpired.ValidTo > DateTime.UtcNow)
                return BadRequest(new AuthorizationResponse { Result = false, Message = "Token no ha expirado..." });

            string userId = _tokenExpired.Claims.First(x =>
            x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

    
            Response<GetAuthorizationResponse>? response = await _authorizer.GetRefreshTokenAsync(request, int.Parse(userId));
            return ApiHelpers.MappingResponse(response, "1.0");
        }
    }
}
