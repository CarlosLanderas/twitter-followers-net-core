using Microsoft.Extensions.Options;
using SocialNetworkReporter.Config.SocialNetwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Streaming;

namespace SocialNetworkReporter.Social.Twitter
{
    public class TwitterUsers
    {
        private IUserStream userStream;
        public TwitterUsers(IOptions<TwitterConfig> twitterConfig)
        {
            userStream = CreateAuthenticatedUserStream(twitterConfig.Value);
            
        }
        private IUserStream CreateAuthenticatedUserStream(TwitterConfig config)
        {
            Auth.SetUserCredentials(config.ConsumerKey, config.ConsumerSecret, config.UserAccessToken, config.UserAccessSecret);
            RateLimit.RateLimitTrackerMode = RateLimitTrackerMode.TrackAndAwait;
            var userStream = Stream.CreateUserStream();            
            return userStream;
        }

        public TwitterQueryResult GetUserFollowers(string userName)
        {
            var user = User.GetUserFromScreenName(userName);
            return new TwitterQueryResult()
            {
                User = user,
                Followers = User.GetFollowerIds(user).Count()
            };
        }
        
    }
}
