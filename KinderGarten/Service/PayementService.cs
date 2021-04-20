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
    public class PayementService
    {

        HttpClient httpClient;

        public PayementService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Statics.baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer{0}", Statics._AccessToken));

        }

        public IEnumerable<PayementSubscription> GetAllPayement()
        {

            var tokenResponse = httpClient.GetAsync(Statics.baseAddress + "accounting/getAllPayement").Result;

            if (tokenResponse.IsSuccessStatusCode)
            {
                var payementSubscriptions = tokenResponse.Content.ReadAsAsync<IEnumerable<PayementSubscription>>().Result;
                return payementSubscriptions;
            }

            return new List<PayementSubscription>();
        }


        public IEnumerable<PayementSubscription> GetAllPayementBySubscription(int id)
        {

            var tokenResponse = httpClient.GetAsync(Statics.baseAddress + "accounting/getAllPayementBySubscription/"+id).Result;
             

            if (tokenResponse.IsSuccessStatusCode)
            {
                var payementSubscriptions = tokenResponse.Content.ReadAsAsync<IEnumerable<PayementSubscription>>().Result;
                return payementSubscriptions;
            }

            return new List<PayementSubscription>();
        }


        

        public IEnumerable<SubscriptionChild> GetAllSubscription()
        {

            var tokenResponse = httpClient.GetAsync(Statics.baseAddress + "accounting/getAllSubscription").Result;

            if (tokenResponse.IsSuccessStatusCode)
            {
                var subscriptions = tokenResponse.Content.ReadAsAsync<IEnumerable<SubscriptionChild>>().Result;
                return subscriptions;
            }

            return new List<SubscriptionChild>();
        }




        public bool AddPayementHandToHand(PayementSubscription payement,String mail,int id)
        {


            

            try
            {


                var APIResponse = httpClient.PostAsJsonAsync<PayementSubscription>(Statics.baseAddress + "accounting/addPayementHandToHand/"+mail+"/"+id,
               payement).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                System.Diagnostics.Debug.WriteLine(APIResponse.Result);




                return true;
            }
            catch
            {
                return false;
            }


        }

        public PayementSubscription FindById(int id)
        {

            var tokenResponse = httpClient.GetAsync(Statics.baseAddress + "accounting/getPayementById/" + id).Result;

            return tokenResponse.Content.ReadAsAsync<PayementSubscription>().Result;
        }

        public bool UpdatePayementSubscription(PayementSubscription payementSubscription)
        {

            try
            {

                


                var APIResponse = httpClient.PutAsJsonAsync<PayementSubscription>(Statics.baseAddress + "accounting/updatePayementHandToHand",
                 payementSubscription).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

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
