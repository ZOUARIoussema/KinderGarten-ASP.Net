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
    public class ExtraService
    {
        HttpClient httpClient;
        public ExtraService(string token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + token));
        }
        public Boolean Add(Extra extra)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Extra>(Statics.baseAddress + "admingarten/addExtra/",
                    extra).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Extra getExtraById(int id)
        {
            Extra Extra = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getExtraById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var extra = response.Content.ReadAsAsync<Extra>().Result;
                return extra;
            }
            return Extra;
        }
        public bool Update(int id, Extra Extra)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Extra>(Statics.baseAddress + "admingarten/updateExtra/" + id, Extra).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteExtraById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "admingarten/deleteExtraById/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Extra> GetAll()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllextra").Result;
            if (response.IsSuccessStatusCode)
            {
                var extra = response.Content.ReadAsAsync<IEnumerable<Extra>>().Result;
                return extra;
            }
            return new List<Extra>();
        }
    }
}
