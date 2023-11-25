using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FabelaExam.Models.Response
{
    public class Response<T>
    {
        [JsonPropertyName("statusCode")]
        public int StatusCode {  get; set; }
        [JsonPropertyName("version")]
        public string Version {  get; set; }
        [JsonPropertyName("content")]
        public T? Content {  get; set; }
    }
}
