using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FabelaExam.Models.Common
{
    public class Message
    {
        [JsonPropertyName("internalMessage")]
        public string? InternalMessage {  get; set; }
    }
}
