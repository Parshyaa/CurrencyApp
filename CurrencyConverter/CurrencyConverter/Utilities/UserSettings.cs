using CurrencyConverter.Utilities.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Utilities
{
    public class UserSettings : IUserSettings
    {
        private IConfigurationRoot Root;
        private IConfigurationSection ApplicationSettings;
        public UserSettings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            Root = configurationBuilder.Build();
            ApplicationSettings = Root.GetSection("UserSettings");
        }
        public string ApiKey => ApplicationSettings["ApiKey"];
    }
}
