using FabelaExam.Models.Common;
using FabelaExam.Models.Request;
using FabelaExam.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabelaExam.Business.Interfaces
{
    public interface IUser
    {
        Task<Response<GetUsersResponse>> GetUser(PaginationFilter filter);
        Task<Response<GetUserResponse>> GetUserById(int userId);

        Task<Response<GetUserResponse>> AddUser(UserRequest request);
        Task<Response<GetUserResponse>> UpdUser(UserRequest request);
        Task<Response<GetUserResponse>> DeleteUser(int userId);
    }
}
