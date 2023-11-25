using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabelaExam.Business.Settings
{
    public interface ISettings
    {
        string strgConnection {  get; }
        string validRol { get; }
        string key
        {
            get;
        }
    }
}
