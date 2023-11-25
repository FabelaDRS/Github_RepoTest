using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FabelaExam.Models.Common
{
    public class CommonResponse
    {
        [JsonPropertyName("errors")]
        public virtual List<Error> Errors { get; set; } = new();
        [JsonPropertyName("messages")]
        public virtual List<Message> Messages { get; set; } = new();

    }
}
