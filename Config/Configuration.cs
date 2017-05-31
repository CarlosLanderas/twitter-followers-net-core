using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkReporter.Config
{
    public class Configuration
    {   
        public static IConfigurationRoot Create(string file = "appsettings.json")
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(file)
                .AddJsonFile("twitterConfiguration.json")
                .Build();
        }
    }
}
