using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SocialNetworkReporter.Config;
using SocialNetworkReporter.Social.Twitter;
using System.IO;
using SocialNetworkReporter.Config;
using System;

namespace SocialNetworkReporter
{
    public class Program
    {
        private static DependencyContainer diContainer;
        public static void Main(string[] args)
        {
            IConfigurationRoot configuration = Configuration.Create();
            diContainer = new DependencyContainer(configuration);

            var twitterUsersClient = diContainer.GetService<TwitterUsers>();
            
            var socialOptions = JsonConvert.DeserializeObject<SocialConfiguration>(File.ReadAllText("twitterConfiguration.json"));
             
            foreach(var enterprise in socialOptions.TwitterEnterprises)
            {
                var queryResult = twitterUsersClient.GetUserFollowers(enterprise);
                Console.WriteLine($"{queryResult.User.ScreenName}: {queryResult.Followers}");

            } 
        }        
    }
}
