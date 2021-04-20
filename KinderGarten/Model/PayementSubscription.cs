using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum TypePayement
    {
        onLine, bankCheck, cash
    }

   public class PayementSubscription
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("dateC")]
        public DateTime DateC { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("typePayement")]
        public TypePayement TypePayement { get; set; }
        [JsonProperty("checkNumber")]
        public int CheckNumber { get; set; }
        [JsonProperty("dateCheck")]
        [DataType(DataType.Date)]
        public DateTime? DateCheck { get; set; }
        [JsonProperty("subscriptionChild")]
        public SubscriptionChild SubscriptionChild { get; set; }
        [JsonProperty("user")]
        public User User { get; set; }



    }
}
