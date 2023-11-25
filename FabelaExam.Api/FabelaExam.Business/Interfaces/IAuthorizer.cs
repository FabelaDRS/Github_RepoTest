using FabelaExam.Models.Authorizer;
using FabelaExam.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabelaExam.Business.Interfaces
{
    public interface IAuthorizer
    {
        Task<Response<GetAuthorizationResponse>> GetTokenAsync(AuthorizationRequest request);
        Task<Response<GetAuthorizationResponse>> GetRefreshTokenAsync(RefreshTokenRequest request, int userId);
    }
}
