using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Application
{
    public static class ExampleClass
    {
        public static IConfigurationService _configurationService;

        public static string ExampleMethod(string key) {
            return _configurationService.GetValue(key);
        }
    }
}
