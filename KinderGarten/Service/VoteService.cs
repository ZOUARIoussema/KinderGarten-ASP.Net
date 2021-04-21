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
        public VoteService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
        }

        public Boolean Add(VoteForm vote, int id, int idsession)
        {
            try
            {
                var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/kinder_garden/" + id + "/delegators").Result;
                var users = response.Content.ReadAsStringAsync().Result;

                var s = JsonConvert.DeserializeObject<User>(users);
                vote.Voter = 7;
                vote.VotedFor = s.Id;
                System.Diagnostics.Debug.WriteLine(s.ToString());
                var APIResponse = httpClient.PostAsJsonAsync<VoteForm>(Statics.baseAddress + "kinder_garden/" + 3 + "/delegators/vote/" + 1,
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
    }
}
