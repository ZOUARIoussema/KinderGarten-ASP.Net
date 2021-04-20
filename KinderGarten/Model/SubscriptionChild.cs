using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class SubscriptionChild
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        public DateTime DateC { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public double Total { get; set; }
        public double TotalPay { get; set; }
        [JsonProperty("restPay")]
        public double RestPay { get; set; }
        public double Discount { get; set; }
        public CategorySubscription CategorySubscription { get; set; }
        public List<Extra> LisExtras { get; set; }
        public Child Child { get; set; }
        public List<PayementSubscription> ListPayementSubscriptions { get; set; }


    }
}
