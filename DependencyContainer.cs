using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using SocialNetworkReporter.Config.SocialNetwork;
using SocialNetworkReporter.Social.Twitter;
using System.Collections.Generic;

namespace SocialNetworkReporter
{
    public class DependencyContainer
    {        
        public IServiceProvider ServiceProvider { get; }
        private readonly IConfigurationRoot Configuration;
        public DependencyContainer(IConfigurationRoot configuration)
        {
            this.Configuration = configuration;

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<TwitterConfig>(Configuration.GetSection(nameof(TwitterConfig)));
            services.AddTransient<TwitterUsers>();
        }

        public T GetService<T>()
        {            
            return (T)ServiceProvider.GetService(typeof(T));
        }
    }
}
