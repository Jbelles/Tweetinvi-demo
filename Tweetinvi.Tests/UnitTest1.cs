using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tweetinvi;

namespace TwitterDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void TestInitialize()
        {
            Auth.SetUserCredentials(
                //Account is @JarretKoder (jarret@koder.ai)
                //PW is KoderDevAccount
                //These 2 keys are specific to Jarret's Developer App
                "XYM4ekZ26J4WLLyEhJ5YXzgB5",
                "GuLBBQCnknzltZZImHbC15mzJZx6gfneeiagrb3Nrf33Xb4zoN",

                //these 2 keys are specific to Jarret's twitter account
                "798968006663507969-TadVbbNzNCGa2P9E8iFC8OTwT3go8qa",
                "90qWXFITcarDrOe3gkvjEveLODnbiZlMeQIhuBJUb2vl1"
    );
        }

        [TestMethod]
        [TestCategory("TweetinviApi")]

        public void VerifyTweetPosted()
        {
            var tweet = Tweet.PublishTweet("Post This Tweet");
            Assert.AreEqual(tweet.Text, "Post This Tweet");
        }

        [TestMethod]
        [TestCategory("TweetinviApi")]

        public void VerifyTweetFavorited()
        {
            bool success = Tweet.FavoriteTweet(799742847310319616);
            Assert.IsTrue(success);
        }

        [TestMethod]
        [TestCategory("TweetinviApi")]

        public void VerifyTweetRetweeted()
        {
            var success = Tweet.PublishRetweet(799742847310319616);
            Assert.IsTrue(success.Retweeted);
        }

        [TestMethod]
        [TestCategory("TweetinviApi")]

        public void VerifyReply()
        {
            var tweet = Tweet.PublishTweetInReplyTo("testing", 799742847310319616);
            Assert.AreEqual(tweet.Text, "testing");
        }
    }
}
