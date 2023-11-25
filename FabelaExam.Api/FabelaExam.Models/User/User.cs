using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FabelaExam.Models.User
{
    public class User
    {
        [JsonPropertyName("userId")]
        public int? UserId { get; set; }
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("age")]
        public int? Age { get; set; }
        [JsonPropertyName("userName")]
        public string? UserName { get; set; }
        [JsonPropertyName("accessCode")]
        public string? AccessCode { get; set; }
        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }
        [JsonPropertyName("createdby")]
        public int? Createdby { get; set; }
        [JsonPropertyName("modifiedAt")]
        public DateTime? ModifiedAt { get; set; }
        [JsonPropertyName("modifiedBy")]
        public int? ModifiedBy { get; set; }
        [JsonPropertyName("isActive")]
        public bool? IsActive { get; set; }


        //public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
