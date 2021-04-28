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
    public class CategorySubscriptionService
    {
        HttpClient httpClient;
        public CategorySubscriptionService(string token)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + token));
        }
        public Boolean Add(CategorySubscription categorySubscription, int idk)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<CategorySubscription>(Statics.baseAddress + "admingarten/addCategorySubscription/" + idk + "/",
                    categorySubscription).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public CategorySubscription getCategorySubscriptionById(int id)
        {
            CategorySubscription CategorySubscription = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getCategorySubscriptionById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var categorySubscription = response.Content.ReadAsAsync<CategorySubscription>().Result;
                return categorySubscription;
            }
            return CategorySubscription;
        }
        public bool Update(int id, CategorySubscription categorySubscription)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<CategorySubscription>(Statics.baseAddress + "admingarten/updateCategorySubscription/" + id, categorySubscription).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteCategorySubscriptionById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "admingarten/deleteCategorySubscriptionById/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<CategorySubscription> GetAll()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllCategorySubscription").Result;
            if (response.IsSuccessStatusCode)
            {
                var categorySubscription = response.Content.ReadAsAsync<IEnumerable<CategorySubscription>>().Result;
                return categorySubscription;
            }
            return new List<CategorySubscription>();
        }


        public IEnumerable<CategorySubscription> CategorySubscriptionByKinderGarten(int kinderId)
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/findAllCategorySubscriptionByKinderGarten/" + kinderId).Result;
            if (response.IsSuccessStatusCode)
            {
                var categorySubscription = response.Content.ReadAsAsync<IEnumerable<CategorySubscription>>().Result;
                return categorySubscription;
            }
            return new List<CategorySubscription>();
        }




    }
}
