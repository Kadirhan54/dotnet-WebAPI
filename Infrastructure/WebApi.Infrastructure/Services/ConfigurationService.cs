using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Application;

namespace WebApi.Infrastructure.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private static ConfigurationService instance;

        public static ConfigurationService GetInstance()
        {
            if (instance == null)
            {
                instance = new ConfigurationService();

            }
            return instance;
        }

        public string GetValue (string key)
        {
            ConfigurationManager configurationManager = new();

            string path = Directory.GetCurrentDirectory();

            configurationManager.SetBasePath(path);

            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetSection(key).Value;

        }

        public ConfigurationService()
        {
            Console.WriteLine("Please use ConfiguratironService.GetInstance method");
        }
    }

}
