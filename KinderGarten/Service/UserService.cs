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
   public  class UserService
    {
        HttpClient httpClient;
        public UserService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));

        }


        public IEnumerable<User> GetAll()
        {
           
            var response = httpClient.GetAsync(Statics.baseAddress + "useradmin/findAll").Result;


            if (response.IsSuccessStatusCode)
            {

                var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
                return users;
            }
            return new List<User>();

        }

        public User GetById(int id)
        {

            User user = null;

            var response = httpClient.GetAsync(Statics.baseAddress + "useradmin/findUser/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var u = response.Content.ReadAsAsync<User>().Result;

                return u;
            }


            return user;

        }

        public bool DeleteUser(int id)
        {

            try
            {
                var APIResponse = httpClient.DeleteAsync(Statics.baseAddress + "useradmin/delete/" + id);

                return true;
            }
            catch
            {
                return false;
            }


        }

    }
}
