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
	public class JustificationAbsenceService
	{
        HttpClient httpClient;
        public JustificationAbsenceService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
        }
        public Boolean Add(JustificationAbsence justificationAbsence)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<JustificationAbsence>(Statics.baseAddress + "parent/addJustification/",
                    justificationAbsence).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
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
