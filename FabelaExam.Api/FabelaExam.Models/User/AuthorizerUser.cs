using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabelaExam.Models.User
{
    public class AuthorizerUser
    {
        public int AuthorizerUserId { get; set; }

        public int? UserId { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ExpiredAt { get; set; }

        public bool? IsActive { get; set; }
    }
}
