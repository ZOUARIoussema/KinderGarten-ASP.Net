using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class SubscriptionChild
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("dateC")]
        [DataType(DataType.Date)]

        public DateTime DateC { get; set; }
        [JsonProperty("dateStart")]
        [DataType(DataType.Date)]
        public DateTime DateStart { get; set; }
        [JsonProperty("dateEnd")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        [JsonProperty("total")]
        public double Total { get; set; }
        [JsonProperty("totalPay")]
        public double TotalPay { get; set; }

        [JsonProperty("restPay")]
        public double RestPay { get; set; }
        [JsonProperty("discount")]
        public double Discount { get; set; }
        [JsonProperty("categorySubscription")]
        public CategorySubscription CategorySubscription { get; set; }
        public int ? CategoryId { get; set; }
        [JsonProperty("lisExtras")]
        public List<Extra> LisExtras { get; set; }

        public int? ExtratId { get; set; }

        public int? ChildId { get; set; }

        [JsonProperty("child")]
        public Child Child { get; set; }
        [JsonProperty("listPayementSubscriptions")]
        public List<PayementSubscription> ListPayementSubscriptions { get; set; }
         


    }
}
