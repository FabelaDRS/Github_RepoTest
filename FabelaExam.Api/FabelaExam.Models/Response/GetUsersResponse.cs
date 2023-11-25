using FabelaExam.Models.Common;
using FabelaExam.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FabelaExam.Models.Response
{
    public class GetUsersResponse: CommonResponse
    {
        public GetUsersResponse() 
        {
            Users = new List<User.User>();
        }

        [JsonPropertyName("users")]
        public List<User.User> Users { get; set; }
    }
}
