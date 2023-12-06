using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application
{
    public interface IConfigurationService
    {
        public string GetValue(string key);
    }
}
