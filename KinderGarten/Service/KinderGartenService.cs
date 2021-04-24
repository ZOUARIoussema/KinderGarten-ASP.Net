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
    public class KinderGartenService
    {

        HttpClient httpClient;
        public KinderGartenService(string token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}"," "+token));
        }
        public Boolean AddKinder(KinderGarten kinder)
        {
            try
            {
             
             
                var APIResponse = httpClient.PostAsJsonAsync<KinderGarten>(Statics.baseAddress + "admingarten/addKinderGarten/",
                    kinder).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public KinderGarten getKindergartenByResponsible(int responsibleId)
        {
            KinderGarten kinderGarten = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getKindergartenByResponsible/" + responsibleId).Result;
            if (response.IsSuccessStatusCode)
            {
                var kinder = response.Content.ReadAsAsync<KinderGarten>().Result;
                return kinder;
            }
            return kinderGarten;
        }

        public KinderGarten getKindergartenById(int id)
        {
            KinderGarten kinderGarten = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getKindergartenById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var kinder = response.Content.ReadAsAsync<KinderGarten>().Result;
                return kinder;
            }
            return kinderGarten;
        }
        public bool UpdateKinder(int id, KinderGarten kinderGarten)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<KinderGarten>(Statics.baseAddress + "admingarten/updateKinderGarten/" + id, kinderGarten).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteKindergartenById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "admingarten/deleteKindergartenById/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<KinderGarten> GetAllKinder()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllkinder").Result;
            if (response.IsSuccessStatusCode)
            {
                var kinder = response.Content.ReadAsAsync<IEnumerable<KinderGarten>>().Result;
                return kinder;
            }
            return new List<KinderGarten>();
        }
    }
}
