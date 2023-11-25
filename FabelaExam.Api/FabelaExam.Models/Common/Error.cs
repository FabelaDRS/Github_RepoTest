using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FabelaExam.Models.Common
{
    public class Error
    {
        [JsonPropertyName("externalMessage")]
        public string? ExternalMessage {  get; set; }
        [JsonPropertyName("internalMessage")]
        public string? InternalMessage {  get; set; }
    }
}
