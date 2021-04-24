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
    public class EstimateService
    {
        HttpClient httpClient;
        public EstimateService(string token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + token));
        }
        public Boolean Add(Estimate e)
        {
            //e.PkEstimate.DateC = new DateTime();
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Estimate>(Statics.baseAddress + "provider/addEstimate/8/3/"+e.Item+"/"+e.Qte+"/"+e.Total+"/",
                    e).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(DateTime dateC,int iduser,int idkinder, Estimate e)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Estimate>(Statics.baseAddress + "provider/updateEstimate/"+dateC+"/"+iduser+"/"+idkinder, e).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteEstimate(DateTime dateC, int iduser, int idkinder)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "provider/deleteEstimate/" + dateC+"/"+ iduser +"/"+ idkinder);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Estimate> GetAll()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "provider/getAllEstimate").Result;
            if (response.IsSuccessStatusCode)
            {
                var Estimate = response.Content.ReadAsAsync<IEnumerable<Estimate>>().Result;
                return Estimate;
            }
            return new List<Estimate>();
        }
    
    public IEnumerable<Estimate> EstimateFilter()
    {
        var response = httpClient.GetAsync(Statics.baseAddress + "provider/getEstimateByKinderAndProvider/"+ 3 + "/"+ 8 + "/").Result;
        if (response.IsSuccessStatusCode)
        {
            var Estimate = response.Content.ReadAsAsync<IEnumerable<Estimate>>().Result;
            return Estimate;
        }
        return new List<Estimate>();
    }
}
}