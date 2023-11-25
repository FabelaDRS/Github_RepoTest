using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabelaExam.Business.Settings
{
    public class SettingServices: ISettings
    {
        private readonly IConfiguration _configuration;

        public SettingServices(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string strgConnection { get => _configuration["ConnectionStrings:cnn"];  }

        public string validRol => throw new NotImplementedException();

        public string key { get => _configuration["JwtSettings:key"];  }
}
}
