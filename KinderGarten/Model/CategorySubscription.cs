using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CategorySubscription
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Required fields")]
        [DataType(DataType.MultilineText)]
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("price")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [JsonProperty("kinderGarten")]
        public KinderGarten KinderGarten { get; set; }
        public List<SubscriptionChild> ListSubscriptionChilds { get; set; }
    }
}
