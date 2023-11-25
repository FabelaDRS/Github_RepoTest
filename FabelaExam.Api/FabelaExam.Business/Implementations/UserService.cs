using FabelaExam.Business.DataContext;
using FabelaExam.Business.Interfaces;
using FabelaExam.Business.Settings;
using FabelaExam.Models.Common;
using FabelaExam.Models.Request;
using FabelaExam.Models.Response;
using FabelaExam.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FabelaExam.Business.Implementations
{
    public class UserService : IUser
    {
        private readonly ISettings _settings;
        private readonly ExamDbContext _dbContext;

        public UserService(ISettings settings, ExamDbContext dbContext)
        {
            _settings = settings;
            _dbContext = dbContext;
        }
        public async Task<Response<GetUserResponse>> AddUser(UserRequest request)
        {
            var response = new Response<GetUserResponse>() { Content = new GetUserResponse() };
            try
            {
                var _data = new User
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Age = request.Age,
                    UserName = request.UserName,
                    AccessCode = request.AccessCode,
                    IsActive = request.IsActive,
                    CreatedAt = DateTime.Now,
                    Createdby = 1
                }; 
                await _dbContext.Users.AddAsync(_data);
                await _dbContext.SaveChangesAsync();

                
                var _result = _dbContext.Users.OrderBy(x => x.UserId).LastOrDefault(); 
                var data = await _dbContext.Users.FindAsync(_result.UserId);
                if (data != null)
                {
                    response.Content.User = data;
                }

            }
            catch (Exception ex)
            {
                response.Content?.Errors?.Add(new Models.Common.Error
                {
                    ExternalMessage = "Ocurrio un error al agregar el usuario.",
                    InternalMessage = ex.ToString()
                });
            }
            return response;
        }
        public async Task<Response<GetUserResponse>> UpdUser(UserRequest request)
        {
            var response = new Response<GetUserResponse>() { Content = new GetUserResponse() };
            try
            {
                var entityProperties = request.GetType().GetProperties();
                var _data = new User
                {
                    UserId = request.UserId,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Age = request.Age,
                    UserName = request.UserName,
                    AccessCode = request.AccessCode,
                    IsActive = request.IsActive,
                    CreatedAt = DateTime.Now,
                    Createdby = 1,   
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = 1
                }; 
                var _result = _dbContext.Entry(_data).State = EntityState.Modified;
                _dbContext.Users.Attach(_data);
                foreach (var ep in entityProperties)
                { 
                    if (ep.Name != "UserId")
                        _dbContext.Entry(_data).Property(ep.Name).IsModified = true;
                }
                await _dbContext.SaveChangesAsync();
                var data = await _dbContext.Users.FindAsync(request.UserId);
                if (data != null)
                {
                    response.Content.User = data;
                }
            }
            catch (Exception ex)
            {
                response.Content?.Errors?.Add(new Models.Common.Error
                {
                    ExternalMessage = "Ocurrio un error al actualizar los datos del usuario.",
                    InternalMessage = ex.ToString()
                });
            }
            return response;
        }
        public async Task<Response<GetUserResponse>> DeleteUser(int userId)
        {
            var response = new Response<GetUserResponse>() { Content = new GetUserResponse() };
            try
            {
                var itemToRemove = _dbContext.Users.SingleOrDefault(x => x.UserId == userId); //returns a single item.

                if (itemToRemove != null)
                {
                    _dbContext.Users.Remove(itemToRemove);
                    _dbContext.SaveChanges();
                    response.Content.User = null;
                    response.Content?.Messages?.Add(new Models.Common.Message
                    {
                        InternalMessage = "El registro se elimino correctamente."
                    });
                }
            }
            catch (Exception ex)
            {
                response.Content?.Errors?.Add(new Models.Common.Error
                {
                    ExternalMessage = "Ocurrio un error al eliminar la cuenta de usuario.",
                    InternalMessage = ex.ToString()
                });
            }
            return response;
        }
        public async Task<Response<GetUsersResponse>> GetUser(PaginationFilter filter)
        {
            var response = new Response<GetUsersResponse>() { Content = new GetUsersResponse() };
            try
            {
                var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                var data = await _dbContext.Users
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();

                //var data = await _dbContext.Users.ToListAsync();
                if (data != null)
                {
                    response.Content.Users = data;
                }
            }
            catch (Exception ex)
            {
                response.Content?.Errors?.Add(new Models.Common.Error
                {
                    ExternalMessage = "Error al consultar la lista de usuarios",
                    InternalMessage = ex.ToString()
                });
            }
            return response;
        }

        public async Task<Response<GetUserResponse>> GetUserById(int userId)
        {
            var response = new Response<GetUserResponse>() { Content = new GetUserResponse() };
            try
            {
                var data = await _dbContext.Users.FindAsync(userId);
                if (data != null)
                    response.Content.User = data;
                else
                {
                    response.Content.User = null;
                    response.Content?.Messages?.Add(new Models.Common.Message
                    {
                        InternalMessage = "No se encontro coincidencias con el Id solicitado."
                    });
                }
                    
            }
            catch (Exception ex)
            {
                response.Content?.Errors?.Add(new Models.Common.Error
                {
                    ExternalMessage = "Error al consultar por Id del usuario.",
                    InternalMessage = ex.ToString()
                });
            }
            return response;
        }


    }
}
