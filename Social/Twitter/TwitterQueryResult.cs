using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace SocialNetworkReporter.Social.Twitter
{
    public class TwitterQueryResult
    {
        public IUser User { get; set; }
        public int Followers { get; set; }
    }
}
