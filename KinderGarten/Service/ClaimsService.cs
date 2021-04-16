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
   public  class ClaimsService
    {
        HttpClient httpClient;
        public ClaimsService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));

        }

      


        public IEnumerable<Claim>GetAll()
        {
          
            var  response = httpClient.GetAsync(Statics.baseAddress+"admin/getAllClaims").Result;
          

            if (response.IsSuccessStatusCode)
            {

               var claims = response.Content.ReadAsAsync<IEnumerable<Claim>>().Result;
            return claims;
            }
        return new List<Claim>();
        }

    }
}
