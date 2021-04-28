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
    public class EventService
    {
        HttpClient httpClient;
        public EventService(string token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + token));
        }
        public Boolean Add(Event e)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Event>(Statics.baseAddress + "admingarten/addEvent/" + e.CategoryId,
                    e).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Event getEventById(int id)
        {
            Event Event = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getEventById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var e = response.Content.ReadAsAsync<Event>().Result;
                return e;
            }
            return Event;
        }
        public bool Update(int id, Event e)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Event>(Statics.baseAddress + "admingarten/updateEvent/" + id, e).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                var Response = httpClient.PutAsJsonAsync<Event>(Statics.baseAddress + "admingarten/affecterEventACategory/" + id + "/" + e.CategoryId, e).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteEventById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "admingarten/deleteEventById/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Event> GetAll()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllevent").Result;
            if (response.IsSuccessStatusCode)
            {
                var Event = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                return Event;
            }
            return new List<Event>();
        }
        public static bool isNumeric(string s)
        {
            return int.TryParse(s, out int n);
        }
        public IEnumerable<Event> getAllEventbyprice(string price)
        {
            if (isNumeric(price))
            {
                int prix = int.Parse(price);
                var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllEventbyprice/" + prix).Result;
                if (response.IsSuccessStatusCode)
                {

                    var Event = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                    return Event;
                }
            }
           
        
            return new List<Event>();
        }

        public IEnumerable<Event> getEventForChild(int idChild)
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getEventForChild/"+idChild).Result;
            if (response.IsSuccessStatusCode)
            {
                var Event = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                return Event;
            }
            return new List<Event>();
        }
        public IEnumerable<Event> GetEventToday()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllEventForToday").Result;
            if (response.IsSuccessStatusCode)
            {
                var Event = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                return Event;
            }
            return new List<Event>();
        }
        public List<String> GetEstimateByEvent(int idEvent)
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getEstimateByEvent/" + idEvent).Result;
            if (response.IsSuccessStatusCode)
            {
                var Event = response.Content.ReadAsAsync<List<String>>().Result;
                return Event;
            }
            return new List<String>();
        }
        public Boolean smsSubmit(Event e,int id_event)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Event>(Statics.baseAddress + "admingarten/sms/"+ id_event+"/8/3/",
                    e).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Event> GetAllEvent()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getAllevent").Result;
            if (response.IsSuccessStatusCode)
            {
                var Event = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                return Event;
            }
            return new List<Event>();
        }

        public Boolean AddParticipate(int id, Event e)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Event>(Statics.baseAddress + "parent/addParticipate/" + id,
                   e).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
    


    }
}