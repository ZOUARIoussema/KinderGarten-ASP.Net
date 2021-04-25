using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService
    {
        HttpClient httpClient;
        public UserService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

           // httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + access));

        }


        public bool UpdateUSer(User userToModify)
        {


            try
            {
                var APIResponse = httpClient.PutAsJsonAsync<User>(Statics.baseAddress + "/user/update",
                 userToModify).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);

                return true;
            }
            catch
            {
                return false;
            }

        }


        public User findUserById(int id)
        {
             
                User u = null;
          
            var response = httpClient.GetAsync(Statics.baseAddress + "user/findUser/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var user = response.Content.ReadAsAsync<User>().Result;


                return user;
            }

            return u;
        }


        public User findUSerByEmail(string email)
        {
            User u = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "user/findUserByEmail/"+email).Result;

            if (response.IsSuccessStatusCode)
            {
                var user = response.Content.ReadAsAsync<User>().Result;

               
                return user;
            }

            return u;
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
