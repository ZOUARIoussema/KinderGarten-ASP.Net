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
    public class ClaimsService
    {
        HttpClient httpClient;
        public ClaimsService(String token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + token));
        }




        public IEnumerable<Claim> GetAll()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "admin/getAllClaims").Result;

            System.Diagnostics.Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Claim> claims = response.Content.ReadAsAsync<IEnumerable<Claim>>().Result;

                return claims;

            }

            return new List<Claim>();
        }


        public String ChangeStateClaim(int idclaim)
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admin/ChangeStateClaim/" + idclaim).Result;

            if (response.IsSuccessStatusCode)
            {
                String messageretour = response.Content.ReadAsStringAsync().Result;

                System.Diagnostics.Debug.WriteLine("state changed " + messageretour);
                return messageretour;
            }
            return "there is an error !";
        }

        public Claim getClaimById (int idclaim)
        {
            Claim cl = null;

            var response = httpClient.GetAsync(Statics.baseAddress + "admin/getClaimById/" + idclaim).Result;

            if (response.IsSuccessStatusCode)
            {
                var claim = response.Content.ReadAsAsync<Claim>().Result;


                return claim;
            }

            return cl;

        }


        public IEnumerable<Claim> getClaimsByParent(String parentname)
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admin/SearchClaimByParent/"+parentname).Result;

            System.Diagnostics.Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                IEnumerable<Claim> claims = response.Content.ReadAsAsync<IEnumerable<Claim>>().Result;

                return claims;

            }

            return new List<Claim>();
        }
    }
}
