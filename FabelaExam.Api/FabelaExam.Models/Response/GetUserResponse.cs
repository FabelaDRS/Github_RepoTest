using FabelaExam.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FabelaExam.Models.Response
{
    public class GetUserResponse: CommonResponse
    {
        public GetUserResponse()
        {
            User = new User.User();
        }

        [JsonPropertyName("user")]
        public User.User? User { get; set; }
    }
}
