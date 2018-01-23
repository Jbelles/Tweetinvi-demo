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
                //These 2 keys are specific to Your Developer App
                "<Key1>",
                "<Key2>",

                //these 2 keys are specific to your twitter account
                "<public>",
                "<private>"
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
