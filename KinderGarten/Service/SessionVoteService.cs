using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SessionVoteService
    {
        HttpClient httpClient;
        public SessionVoteService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
        }
        public Boolean Add(SessionVote sessionVote)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<SessionVote>(Statics.baseAddress + "admingarten/addSessionVote/",
                    sessionVote).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public SessionVote getSessionVoteById(int id)
        {
            SessionVote SessionVote = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getSessionVoteById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var sessionVote = response.Content.ReadAsAsync<SessionVote>().Result;
                return sessionVote;
            }
            return SessionVote;
        }
        public bool Update(int id, SessionVote sessionVote)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<SessionVote>(Statics.baseAddress + "admingarten/updateSessionVote/" + id, sessionVote).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteSessionVoteById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "admingarten/deleteSessionVoteById/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<SessionVote> GetAll()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllSessionVote").Result;
            if (response.IsSuccessStatusCode)
            {
                var sessionVote = response.Content.ReadAsAsync<IEnumerable<SessionVote>>().Result;
                return sessionVote;
            }
            return new List<SessionVote>();
        }
    }
}