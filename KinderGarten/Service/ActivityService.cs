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
    public class ActivityService
    {
        HttpClient httpClient;
        public ActivityService(string token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + token));
        }
        public Boolean Add(Activity activity)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Activity>(Statics.baseAddress + "admingarten/addActivity/",
                    activity).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Activity getActivityById(int id)
        {
            Activity Activity = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getActivityById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var activity = response.Content.ReadAsAsync<Activity>().Result;
                return activity;
            }
            return Activity;
        }
        public bool Update(int id, Activity activity)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Activity>(Statics.baseAddress + "admingarten/updateActivity/" + id, activity).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteActivityById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "admingarten/deleteActivityById/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Activity> GetAll()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllactivity").Result;
            if (response.IsSuccessStatusCode)
            {
                var activity = response.Content.ReadAsAsync<IEnumerable<Activity>>().Result;
                return activity;
            }
            return new List<Activity>();
        }
        public bool deleteAllActivity(int kinderId, Activity activity)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Activity>(Statics.baseAddress + "admingarten/deleteAllActivity/" + kinderId, activity).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Activity> ActivityByKinderGarten(int kinderId)
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/findAllActivityByKinderGarten/"+kinderId).Result;
            if (response.IsSuccessStatusCode)
            {
                var activity = response.Content.ReadAsAsync<IEnumerable<Activity>>().Result;
                return activity;
            }
            return new List<Activity>();
        }
    }
}