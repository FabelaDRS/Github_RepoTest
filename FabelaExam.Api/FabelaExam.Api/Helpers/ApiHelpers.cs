using FabelaExam.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace FabelaExam.Api.Helpers
{
    public static class ApiHelpers
    {
        public static ObjectResult MappingResponse<T>(Response<T> content, string version)
        {
            content.Version = version;
            ObjectResult? response = default;
            content.StatusCode = 200;
            response = new ObjectResult(content)
            {
                StatusCode = 200
            };

            return response;
        }
    }
}
