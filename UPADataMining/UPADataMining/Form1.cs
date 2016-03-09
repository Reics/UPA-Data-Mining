using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinqToTwitter;
using System.Text.RegularExpressions;

namespace UPADataMining
{
    public partial class Form1 : Form
    {
        private SingleUserAuthorizer authorizer =
   new SingleUserAuthorizer
   {
       CredentialStore =
      new SingleUserInMemoryCredentialStore
      {
          ConsumerKey =
          "y3Ol07sVw4QkoRR3rLnbhIiKU",
          ConsumerSecret =
         "dez2FLZPt5qG8fckOfXOtLEskbnSucZPSa2u5NlVaooJcLhwoy",
          AccessToken =
         "75399413-B7FydbF7YbmVChb4YfSyru4YvMNLX6qFQoQhv84gp",
          AccessTokenSecret =
         "jFkPIAEZ2jB1LT7ismgLPcJC6XGUB48M4av84Jo07LSea"
      }
   };

        public Form1()
        {
            InitializeComponent();

            GetMostRecent200HomeTimeLine();
            lstTweetList.Items.Clear();
            currentTweets.ForEach(tweet =>
               lstTweetList.Items.Add(tweet.Text));
            GetSideBarList(GetFollowers()).ForEach(name =>
   lstFollowNames.Items.Add(name));
        }

        private List<Status> currentTweets;

        private void GetMostRecent200HomeTimeLine()
        {
            var twitterContext = new TwitterContext(authorizer);

            var tweets = from tweet in twitterContext.Status
                         where tweet.Type == StatusType.Home &&
                         tweet.Count == 200
                         select tweet;

            currentTweets = tweets.ToList();
        }

        private List<string> GetFollowers()
        {
            List<string> results = new List<string>();

            var twitterContext = new TwitterContext(authorizer);

            var temp = Enumerable.FirstOrDefault(from friend in
               twitterContext.Friendship
                                                 where friend.Type == FriendshipType.FollowersList &&
                                                    friend.ScreenName == "shawty_ds" &&
                                                    friend.Count == 200
                                                 select friend);

            if (temp != null)
            {
                temp.Users.ToList().ForEach(user => results.Add(user.Name));

                while (temp != null && temp.CursorMovement.Next != 0)
                {
                    temp = Enumerable.FirstOrDefault(from friend in
                       twitterContext.Friendship
                                                     where friend.Type == FriendshipType.FollowersList &&
                                                        friend.ScreenName == "shawty_ds" &&
                                                        friend.Count == 200 &&
                                                        friend.Cursor == temp.CursorMovement.Next
                                                     select friend);

                    if (temp != null) temp.Users.ToList().ForEach(user =>
                       results.Add(user.Name));
                }
            }

            return results;
        }

        private List<string> GetSideBarList(List<string> inputNames)
{
   List<string> results = new List<string>();
 
   foreach (string name in inputNames)
   {
      int tweetCount = currentTweets.Count(tweet =>
         tweet.User.Name == name);
      if(tweetCount > 0)
      {
         results.Add(string.Format("{0} ({1})",
            name, tweetCount));
      }
      else
      {
         results.Add(string.Format("{0}", name));
      }
   }
 
   return results;
}

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            lstTweetList.Items.Clear();
            currentTweets.ForEach(tweet =>
               lstTweetList.Items.Add(tweet.User.Name + ":"
               + tweet.Text));
        }

        private void lstFollowNames_SelectedIndexChanged(object sender, EventArgs e)
        {

            lstTweetList.Items.Clear();
            var selectedName =
               (sender as ListBox).SelectedItem.ToString();
            string pattern = @"^(.*)\s\(\d{0,4}\)$";

            Match match = Regex.Match(selectedName, pattern);

            if (match.Success)
            {
                // We have a name with a count appended
                selectedName = match.Groups[1].Value.Trim();
            }

            foreach (var tweet in currentTweets.Where(tweet =>
                tweet.User.Name == selectedName))
            {
                lstTweetList.Items.Add(tweet.User.Name + ":"
                   + tweet.Text);
            }
        }

        private List<Status> SearchTwitter(string searchTerm)
        {
            var twitterContext = new TwitterContext(authorizer);

            var srch =
               Enumerable.SingleOrDefault((from search in
                  twitterContext.Search
                                           where search.Type == SearchType.Search &&
                                     search.Query == searchTerm &&
                                     search.Count == 200
                                           select search));
            if (srch != null && srch.Statuses.Count > 0)
            {
                return srch.Statuses.ToList();
            }

            return new List<Status>();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchTerm.Text))
            {
                MessageBox.Show("Please enter a term to search for");
                return;
            }
            var results = SearchTwitter(txtSearchTerm.Text);
            lstTweetList.Items.Clear();
            results.ForEach(tweet =>
               lstTweetList.Items.Add(tweet.User.Name + ":"
               + tweet.Text));
        }
    }
}
