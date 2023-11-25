using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabelaExam.Models.Authorizer
{
    public class AuthorizationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
