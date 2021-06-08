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
    public class UserAdminService
    {
        HttpClient httpClient;

        private UserService userservice = new UserService();

        public UserAdminService(String accessToken)
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", " " + accessToken));
        }


        public IEnumerable<User> getAll()
        {

            var response = httpClient.GetAsync(Statics.baseAddress + "useradmin/findAll").Result;


            System.Diagnostics.Debug.WriteLine(response.StatusCode);

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

        public String changeStateUser(int id)
        {
            // User userstate = userservice.findUserById(id);


            var APIResponse = httpClient.GetAsync(Statics.baseAddress + "useradmin/ChangeStateUser/" + id).Result;

            if (APIResponse.IsSuccessStatusCode)    
            {
                String messageretour = APIResponse.Content.ReadAsStringAsync().Result;

                System.Diagnostics.Debug.WriteLine("state user changed " + messageretour);
                return messageretour;
            }
            return "there is an error !";


        }


        public IEnumerable<User> getParentsByKinderGarten()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "useradmin/getParentsByKinderGarten").Result;


            System.Diagnostics.Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                var users = response.Content.ReadAsAsync<IEnumerable<User>>().Result;

                return users;
            }

            return new List<User>();
        }


        public int ChildSubscribed ()
        {
            int c = 0;

            var response = httpClient.GetAsync(Statics.baseAddress + "admin/getChildsSubscribed").Result;


            System.Diagnostics.Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                int count = response.Content.ReadAsAsync<int>().Result;

                System.Diagnostics.Debug.WriteLine("nbr child subscribed 2021 "+count);

                return count;
            }
            return c;
        }

        public int UsersRegistred()
        {
            int c = 0;

            var response = httpClient.GetAsync(Statics.baseAddress + "admin/getNbrUsersRegistered").Result;


            System.Diagnostics.Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                int count = response.Content.ReadAsAsync<int>().Result;

                System.Diagnostics.Debug.WriteLine("nbr users registred " + count);

                return count;
            }
            return c;
        }
        

             public int UsersRegistredThisMonth()
        {
            int c = 0;

            var response = httpClient.GetAsync(Statics.baseAddress + "admin/UsersSubscribedThisMonth").Result;


            System.Diagnostics.Debug.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                int count = response.Content.ReadAsAsync<int>().Result;

                System.Diagnostics.Debug.WriteLine("nbr users registred this month" + count);

                return count;
            }
            return c;
        }


        public MaxScoreEval getMaxScoreEval()

        {
            MaxScoreEval mseval = null;
            var response = httpClient.GetAsync(Statics.baseAddress + "admin/getMaxScoreEval").Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

               MaxScoreEval maxscorename = JsonConvert.DeserializeObject<MaxScoreEval>(content);

                System.Diagnostics.Debug.WriteLine(maxscorename.ToString());

                return maxscorename;
            }

            return mseval;

        }

        public IEnumerable<KinderGarten> GetAllKinder()
        {
            var response = httpClient.GetAsync(Statics.baseAddress + "admin/getAllKindergarten").Result;

            if (response.IsSuccessStatusCode)
            {
                var kinder = response.Content.ReadAsAsync<IEnumerable<KinderGarten>>().Result;
                return kinder;
            }
            return new List<KinderGarten>();
        }



      

    }
}
