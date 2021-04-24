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
	public class ChildService
	{
		HttpClient httpClient;
        public ChildService()
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
        }
        public Boolean Add(Child child)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Child>(Statics.baseAddress + "parent/addChild/",
                    child).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Child> getAllChild()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getAllChild").Result;


            System.Diagnostics.Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                var child = response.Content.ReadAsAsync<IEnumerable<Child>>().Result;

                return child;
            }

            return new List<Child>();

        }
    }
}
