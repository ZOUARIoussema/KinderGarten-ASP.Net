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
    public class CategoryService
    {
        HttpClient httpClient;
        public CategoryService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));
        }
        public Boolean Add(Category category)
        {
            try
            {
                var APIResponse = httpClient.PostAsJsonAsync<Category>(Statics.baseAddress + "admingarten/addCategory/",
                    category).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Category getCategoryById(int id)
        {
            Category Category = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getCategoryById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var category = response.Content.ReadAsAsync<Category>().Result;
                return category;
            }
            return Category;
        }
        public bool Update(int id, Category category)
        {
            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<Category>(Statics.baseAddress + "admingarten/updateCategory/" + id, category).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteCategoryById(int id)
        {
            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "admingarten/deleteCategoryById/" + id);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public IEnumerable<Category> GetAll()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admingarten/getAllcategory").Result;
            if (response.IsSuccessStatusCode)
            {
                var category = response.Content.ReadAsAsync<IEnumerable<Category>>().Result;
                return category;
            }
            return new List<Category>();
        }
    }
}