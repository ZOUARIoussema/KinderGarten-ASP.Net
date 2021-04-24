using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VoteService
    {
        HttpClient httpClient;
        public VoteService(string token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + token));
        }

        public Boolean Add(VoteForm vote, int idVotedFor)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<VoteForm>(Statics.baseAddress + "admingarten/kinder_garden/3/delegators/vote/1/",
                    vote).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<User> GetAll()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/kinder_garden/3/delegators").Result;

            if (response.IsSuccessStatusCode)
            {

                var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                return users;
            }
            return new List<User>();
        }

        public User delegatorsElection(int idkinder)
        {
            User u = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/kinder_garden/" + idkinder + "/delegator/validate/").Result;
            if (response.IsSuccessStatusCode)
            {
                var user = response.Content.ReadAsAsync<User>().Result;
                return user;
            }
            return u;
        }
        
    }
}
