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
    public class MeetingService
    {
        HttpClient httpClient;
        public MeetingService(string token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + token));
        }
        public Boolean Add(Meeting meeting)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Meeting>(Statics.baseAddress + "admingarten/addMeeting/",
                    meeting).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Meeting getMeetingById(int id)
        {
            Meeting Meeting = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getMeetingById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var meeting = response.Content.ReadAsAsync<Meeting>().Result;
                return meeting;
            }
            return Meeting;
        }
        public bool Update(int id, Meeting meeting)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Meeting>(Statics.baseAddress + "admingarten/updateMeeting/" + id, meeting).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteMeetingById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "admingarten/deleteMeetingById/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Meeting> GetAll()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllmeeting").Result;
            if (response.IsSuccessStatusCode)
            {
                var meeting = response.Content.ReadAsAsync<IEnumerable<Meeting>>().Result;
                return meeting;
            }
            return new List<Meeting>();
        }
    }
}
