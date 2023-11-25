using FabelaExam.Business.DataContext;
using FabelaExam.Business.Interfaces;
using FabelaExam.Business.Settings;
using FabelaExam.Models.Authorizer;
using FabelaExam.Models.Response;
using FabelaExam.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FabelaExam.Business.Implementations
{
    public class AuthorizerService: IAuthorizer
    {
        private readonly ISettings _settings;
        private readonly ExamDbContext _dbContext;
        public AuthorizerService(ISettings settings, ExamDbContext dbContext)
        {
            _settings = settings;
            _dbContext = dbContext;
        }

        public async Task<Response<GetAuthorizationResponse>> GetRefreshTokenAsync(RefreshTokenRequest request, int userId)
        {
            Response<GetAuthorizationResponse>? response = new Response<GetAuthorizationResponse>() { Content = new GetAuthorizationResponse() };
            try
            {
                var _refreshTokenFound = _dbContext.AuthorizerUsers.FirstOrDefault(x =>
                    x.Token == request.ExpiredToken &&
                    x.RefreshToken == request.RefreshToken &&
                    x.UserId == userId
                );

                if (_refreshTokenFound != null)
                {
                    var _refreshTokenBuild = BuildRefreshToken();
                    var _token = BuildToken(userId.ToString());

                    var _result = await SaveTokenLog(userId, _token, _refreshTokenBuild);

                    response.Content.Authorization = new Authorization()
                    {
                        Token = _result.Token,
                        RefreshToken = _result.RefreshToken,
                        Message = "OK",
                        Result = true
                    };
                }
                else
                {
                    response.Content.Authorization = null;
                    response.Content?.Errors?.Add(new Models.Common.Error
                    {
                        ExternalMessage = "No fue posible reestablecer el Token.",
                        InternalMessage = ""
                    });
                } 
            }
            catch (Exception ex)
            {
                response.Content?.Errors?.Add(new Models.Common.Error
                {
                    ExternalMessage = "Refresh Token no generado.",
                    InternalMessage = ex.ToString()
                });
            }
            return response;
        }

        public async Task<Response<GetAuthorizationResponse>> GetTokenAsync(AuthorizationRequest request)
        {
            
            Response<GetAuthorizationResponse>? response = new Response<GetAuthorizationResponse>() { Content = new GetAuthorizationResponse() };
            try
            {
                var data = await _dbContext.Users.Where(x => x.UserName == request.UserName && x.AccessCode == request.Password).FirstOrDefaultAsync();
                if (data != null)
                {
                    string _token = BuildToken(data.UserId.ToString());
                    string _refreshToken = BuildRefreshToken();
                    var _result = await SaveTokenLog(data.UserId.Value, _token, _refreshToken);

                    response.Content.Authorization = new Authorization()
                    {
                         Token = _result.Token,
                         RefreshToken = _result.RefreshToken,   
                         Message = "OK",
                         Result = true
                    };
                }
                else
                {
                    response.Content.Authorization = null;
                    response.Content?.Errors?.Add(new Models.Common.Error
                    {
                        ExternalMessage = "No existe la cuenta con las credenciales proporcionadas.",
                        InternalMessage = ""
                    });
                }
            }
            catch (Exception ex)
            {
                response.Content?.Errors?.Add(new Models.Common.Error
                {
                    ExternalMessage = "",
                    InternalMessage = ex.ToString()
                });
            }
            return response;
        }

        private async Task<AuthorizationResponse> SaveTokenLog(int userId, string token, string refreshToken)
        {
            var historic = new AuthorizerUser
            {
                UserId = userId,
                Token = token,
                RefreshToken = refreshToken,
                CreatedAt = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddMinutes(3)
            };

            await _dbContext.AuthorizerUsers.AddAsync(historic);
            await _dbContext.SaveChangesAsync();
            return new AuthorizationResponse { Message = "OK", Token = token, RefreshToken = refreshToken, Result = true };
        }
        private string BuildToken(string userId)
        {
            var key = _settings.key;
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            //var keyBytes = Encoding.ASCII.GetBytes(key);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId));

            var sign_token = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature);

            var token_descript = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = sign_token
            };

            var _tokenHandler = new JwtSecurityTokenHandler();
            var _tokenConfig = _tokenHandler.CreateToken(token_descript);

            string _token = _tokenHandler.WriteToken(_tokenConfig);
            return _token;
        }

        private string BuildRefreshToken()
        {
            var byteArr = new byte[64];
            var refreshToken = "";
            using (var rnm = RandomNumberGenerator.Create())
            {
                rnm.GetBytes(byteArr);
                refreshToken = Convert.ToBase64String(byteArr);
            }
            return refreshToken;
        }
    }
}
