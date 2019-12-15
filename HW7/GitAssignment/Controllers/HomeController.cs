using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GitAssignment.Controllers
{
    public class HomeController : Controller
    {
        // ActionResult displays user and repo information
        public ActionResult Index()
        {
            // access secret token
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["token"];

            // get user info
            string userInfo = SendRequest("Https://api.github.com/user", apiKey, "Victoria-Rhine");
            Person person = JsonConvert.DeserializeObject<Person>(userInfo);
            ViewData["myPerson"] = person;

            // get repo info
            string repoInfo = SendRequest("Https://api.github.com/user/repos", apiKey, "Victoria-Rhine");
            var repo = JsonConvert.DeserializeObject<List<Repos>>(repoInfo);
            ViewData["myRepo"] = repo;

            return View();
        }

        // GET requests from C# to GitHub's API
        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;
            request.Accept = "application/json";

            string jsonString = null;
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }

        // generate JSON from an action method
        public ActionResult Commits()
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["token"];
            string username = Request.QueryString["user"];
            string newUrlName = "https://api.github.com/repos/" + username + "/" + Request.QueryString["repo"] + "/commits";  
            string json = SendRequest(newUrlName, apiKey, username);
            JArray gitInfo = JArray.Parse(json);
            
            List<CommitModel> commitList = new List<CommitModel>();

            for (int i = 0; i < gitInfo.Count; i++)
            {
                string sha = (string)gitInfo[i]["sha"];
                string committer = (string)gitInfo[i]["commit"]["committer"]["name"];
                string date = (string)gitInfo[i]["commit"]["committer"]["date"];
                string message = (string)gitInfo[i]["commit"]["message"];
                string commitUrl = (string)gitInfo[i]["html_url"];
                commitList.Add(new CommitModel()
                {
                    Sha = sha,
                    Committer = committer,
                    Date = date,
                    Message = message,
                    CommitUrl = commitUrl
                });
            }

            return new ContentResult
            {
                // serialize C# object "commits" to JSON using Newtonsoft.Json.JsonConvert
                Content = JsonConvert.SerializeObject(commitList),
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };
        }
    }

    // class to gather needed user information
    public class Person
    {
        public string avatar_url { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string location { get; set; }
        public string html_url { get; set; }
        public string company { get; set; }
    }

    // class to gather repo information
    public class Repos
    {
        public string name { get; set; }
        public Owner owner { get; set; }
        public string commits_url { get; set; }
        public DateTime updated_at { get; set; }
        public string html_url { get; set; }
    }

    // class to gather repo owner information
    public class Owner
    {
        public string login { get; set; }
        public string avatar_url { get; set; }
    }

    // class to gather repo commit information
    public class CommitModel
    {
        public string Sha { get; set; }
        public string Committer { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public string CommitUrl { get; set; }
    }
}