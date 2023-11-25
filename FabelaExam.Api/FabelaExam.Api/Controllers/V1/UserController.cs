using Azure.Core;
using FabelaExam.Api.Helpers;
using FabelaExam.Business.Interfaces;
using FabelaExam.Models.Common;
using FabelaExam.Models.Request;
using FabelaExam.Models.Response;
using FabelaExam.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FabelaExam.Api.Controllers.V1
{
   
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        internal readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationFilter filter)
        {
            Response<GetUsersResponse>? response = await _user.GetUser(filter);
            return ApiHelpers.MappingResponse(response, "1.0");
        }
        [Authorize]
        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> Get(int userId)
        {
            Response<GetUserResponse>? response = await _user.GetUserById(userId);
            return ApiHelpers.MappingResponse(response, "1.0");
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequest request)
        {
            Response<GetUserResponse>? response = await _user.AddUser(request);
            return ApiHelpers.MappingResponse(response, "1.0");
        }

        //[Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserRequest request)
        {
            Response<GetUserResponse>? response = await _user.UpdUser(request);
            return ApiHelpers.MappingResponse(response, "1.0");
        }

        //[Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            Response<GetUserResponse>? response = await _user.DeleteUser(userId);
            return ApiHelpers.MappingResponse(response, "1.0");
        }
    }
}
