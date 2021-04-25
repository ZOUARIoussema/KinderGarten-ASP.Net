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
	public class SubscriptionChildService
	{
        HttpClient httpClient;
        public SubscriptionChildService()
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
        }
        public Boolean Add(SubscriptionChild subscriptionChild)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<SubscriptionChild>(Statics.baseAddress + "parent/addSubscriptionChild/"+subscriptionChild.CategoryId,
                    subscriptionChild).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateSubscriptionChild(SubscriptionChild subscriptionChild)
        {


            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<SubscriptionChild>(Statics.baseAddress + "parent/updateSubscription/" + subscriptionChild.Id,
                 subscriptionChild).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool DeleteSubscriptionChild(int id)
        {

            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "parent/deleteSubscriptionChild/" + id);

                return true;
            }
            catch
            {
                return false;
            }
        }
        public SubscriptionChild GetById(int id)
        {

            SubscriptionChild subscriptionChild = null;

            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getSubscriptionById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var sub = response.Content.ReadAsAsync<SubscriptionChild>().Result;

                return sub;
            }


            return subscriptionChild;

        }

        public CategorySubscription getCategorySubscriptionById(int id)
        {
            CategorySubscription CategorySubscription = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getCategorySubscriptionById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var categorySubscription = response.Content.ReadAsAsync<CategorySubscription>().Result;
                return categorySubscription;
            }
            return CategorySubscription;
        }


        public IEnumerable<CategorySubscription> GetAllCategorySubscription()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getAllCategorySubscription").Result;
            System.Diagnostics.Debug.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                var categorySubscription = response.Content.ReadAsAsync<IEnumerable<CategorySubscription>>().Result;
                return categorySubscription;
            }
            return new List<CategorySubscription>();
        }

        public Extra getExtraById(int id)
        {
            Extra Extra = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getExtraById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var extra = response.Content.ReadAsAsync<Extra>().Result;
                return extra;
            }
            return Extra;
        }

        public IEnumerable<Extra> GetAllExtra()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "parent/getAllextra").Result;
            if (response.IsSuccessStatusCode)
            {
                var extra = response.Content.ReadAsAsync<IEnumerable<Extra>>().Result;
                return extra;
            }
            return new List<Extra>();
        }
    }
}
