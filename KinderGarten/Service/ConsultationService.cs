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
    public class ConsultationService
    {
        HttpClient httpClient;
        
        public ConsultationService( String accessToken)
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}"," "+accessToken));

        }

        public IEnumerable<Consultation>GetAll()
        {

            var tokenResponse = httpClient.GetAsync(Statics.baseAddress + "medical/getAllConsultation").Result;

            if (tokenResponse.IsSuccessStatusCode)
            {
                var consultations = tokenResponse.Content.ReadAsAsync<IEnumerable<Consultation>>().Result;
                return consultations;
            }

            return new List<Consultation>();
        }

        public Consultation GetById(int id)
        {

            var tokenResponse = httpClient.GetAsync(Statics.baseAddress + "medical/getConsultationById/" + id).Result;

            return tokenResponse.Content.ReadAsAsync<Consultation>().Result;

        }

        public bool Add(Consultation consultation)
        {

            try
            {


                var APIResponse = httpClient.PostAsJsonAsync<Consultation>(Statics.baseAddress + "medical/addMedicalConsultation",
               consultation).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);




                return true;
            }
            catch
            {
                return false;
            }


        }

        public bool DeleteConsultation(int id)
        {

            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "medical/deleteConsultation/" + id);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Consultation consultation)
        {
            System.Diagnostics.Debug.WriteLine(consultation.FolderMedical.Id);

            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Consultation>(Statics.baseAddress + "medical/updateConsultationMedical/" ,
                 consultation).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

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
