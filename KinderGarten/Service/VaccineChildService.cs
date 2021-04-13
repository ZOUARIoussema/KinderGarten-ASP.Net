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
    public class VaccineChildService
    {


        HttpClient httpClient;

        public VaccineChildService()
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));

        }


        public IEnumerable<ChildVaccine> GetAll()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "medical/getAllChildVaccine").Result;

            

            if (response.IsSuccessStatusCode)
            {
                var vaccines = response.Content.ReadAsAsync<IEnumerable<ChildVaccine>>().Result;
                return vaccines;
            }

            return (new List<ChildVaccine>());

        }

        public bool AddVaccine(ChildVaccine childVaccine)
        {
            try
            {


                var APIResponse = httpClient.PostAsJsonAsync<ChildVaccine>(Statics.baseAddress + "medical/addVaccineChild",
               childVaccine).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);




                return true;
            }
            catch
            {
                return false;
            }

        } 


        public ChildVaccine GetById(int id)
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "medical/getVaccineById/" + id).Result;

           
             
                 return response.Content.ReadAsAsync<ChildVaccine>().Result;
             

        } 

        public bool Delete(int id)
        {

            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "medical/delete/" + id);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateVaccine(ChildVaccine childVaccine)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<ChildVaccine>(Statics.baseAddress + "medical/updateVaccineChild",
                 childVaccine).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

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
