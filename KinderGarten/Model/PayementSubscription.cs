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
        [DataType(DataType.Date)]
        [JsonProperty("dateC")]
        public DateTime DateC { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("typePayement")]
        public TypePayement TypePayement { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
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
