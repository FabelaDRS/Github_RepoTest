using FabelaExam.Models.Authorizer;
using FabelaExam.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FabelaExam.Models.Response
{
    public class GetAuthorizationResponse: CommonResponse
    {
        public GetAuthorizationResponse() 
        {
            Authorization = new Authorization();
        }

        [JsonPropertyName("auth")]
        public Authorization? Authorization { get; set; }
             
    }
}
