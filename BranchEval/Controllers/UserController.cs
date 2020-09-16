using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BranchEval.Controllers
{
    
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        //The base github API URL that will be used when making REST API calls
        public string baseUrl = "https://api.github.com/users";

        //Very simple caching mechanism so each username only has to be queried once per endpoint
        public static Dictionary<string, JToken> userCache = new Dictionary<string, JToken>();
        public static Dictionary<string, JToken> userRepoCache = new Dictionary<string, JToken>();

        //If the user calls "api/user" without the actual username, they will receive this message back
        [HttpGet]
        public string Get()
        {
            return "Please add the username to the endpoint to get information for a specific GitHub user.";
        }


        //Call "api/user/{user}" to get the info for a specific GitHub user
        [HttpGet]
        [Route("{user}")]
        public async Task<JToken> GetUser(string user)
        {
            //If the API call has already been made, read it from the cache instead
            if (userCache.ContainsKey(user)) return userCache[user];

            //Set up call to GitHub API user endpoint
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest(user);

            //Make the REST call
            var response = await client.ExecuteGetAsync(request);

            //Determine what error text to display to the user based on the error returned from GitHub.
            if (response.StatusCode == HttpStatusCode.NotFound) return GetErrorResponse(response.StatusCode, user);

            //Add the response to the cache
            userCache.Add(user, JValue.Parse(response.Content));

            //return JToken.Parse(response.Content).ToString(Formatting.Indented);
            return JValue.Parse(response.Content);
        }

        //Call "api/user/{user}/repos" to get the repose for a specific GitHub user
        [HttpGet]
        [Route("{user}/repos")]
        public async Task<JToken> GetUserRepo(string user)
        {
            //If the API call has already been made, read it from the cache instead
            if (userRepoCache.ContainsKey(user)) return userRepoCache[user];

            //Set up call to GitHub API user/repos endpoint
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest(user + "/repos");

            //Make the REST call
            var response = await client.ExecuteGetAsync(request);

            //Determine what error text to display to the user based on the error returned from GitHub.
            if (response.StatusCode == HttpStatusCode.NotFound) return GetErrorResponse(response.StatusCode, user);

            //Add the response to the cache, so that this specific username will not have to be queried again
            userRepoCache.Add(user, JValue.Parse(response.Content));

            return JValue.Parse(response.Content);
        }


        //The error handling can easily be expanded upon if necessary
        public string GetErrorResponse(HttpStatusCode statusCode, string user)
        {
            switch (statusCode)
            {
                case HttpStatusCode.NotFound: return "No GitHub user found with the username '" + user + "'.";
            }

            return "An error has occurred. Please try again later.";
        }
    }
}
