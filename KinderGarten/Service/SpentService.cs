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
   public class SpentService
    {


        HttpClient httpClient;

        public SpentService(String accessToken)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " "+ accessToken));

        }

        public IEnumerable<Spent> getAll(int id )
        {

            var tokenResponse = httpClient.GetAsync(Statics.baseAddress + "accounting/getAllSpentByAgent/"+id).Result;

            if (tokenResponse.IsSuccessStatusCode)
            {
                var spents = tokenResponse.Content.ReadAsAsync<IEnumerable<Spent>>().Result;
                return spents;
            }

            return new List<Spent>();
        }

        public bool AddSpent(Spent spent)
        {
 

            spent.DateC = new DateTime();

            System.Diagnostics.Debug.WriteLine(spent);


            try
            {


                var APIResponse = httpClient.PostAsJsonAsync<Spent>(Statics.baseAddress + "accounting/addSpent",
               spent).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);




                return true;
            }
            catch
            {
                return false;
            }


        }

        public Spent FindById(int id)
        {

            var tokenResponse = httpClient.GetAsync(Statics.baseAddress + "accounting/getSpentById/" + id).Result;

            return tokenResponse.Content.ReadAsAsync<Spent>().Result; 
        }

        public bool UpdateSpent(Spent spent)
        {

            try
            {
                 


                var APIResponse = httpClient.PutAsJsonAsync<Spent>(Statics.baseAddress + "accounting/updateSpent",
                 spent).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool DeleteSpent(int id)
        {

            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "accounting/deleteSpent/" + id);

                return true;
            }
            catch
            {
                return false;
            }

        }




       

    }
}
