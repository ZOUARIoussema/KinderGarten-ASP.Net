using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
   public class MedicalVisitService
    {

        HttpClient httpClient;

        public MedicalVisitService()
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));

        }


        public IEnumerable<MedicalVisitKinderGarten> GetAll()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "medical/getAllMedicalVisit").Result;



            if (response.IsSuccessStatusCode)
            {
                var v = response.Content.ReadAsAsync<IEnumerable<MedicalVisitKinderGarten>>().Result;
                return v;
            }

            return (new List<MedicalVisitKinderGarten>());

        }

        public bool AddMedicalVisit(MedicalVisitKinderGarten m)
        {
            try
            {

                System.Diagnostics.Debug.WriteLine("** service** " + m);

                var APIResponse = httpClient.PostAsJsonAsync<MedicalVisitKinderGarten>(Statics.baseAddress + "medical/addMedicalVisit",
               m).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);




                return true;
            }
            catch
            {
               
                return false;
            }

        }


        public bool Delete(int id)
        {

            System.Diagnostics.Debug.WriteLine("** service** " +id);

            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "medical/deleteVisitMedical/" + id);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Update(MedicalVisitKinderGarten m)
        {

            System.Diagnostics.Debug.WriteLine("** service** " + m);

            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<MedicalVisitKinderGarten>(Statics.baseAddress + "medical/updateMedicalVisit/",
                 m).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

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
