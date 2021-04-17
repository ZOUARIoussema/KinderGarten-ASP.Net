using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Extra
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        public List<SubscriptionChild> ListSubscriptionChilds { get; set; }
        [JsonProperty("kinderGarten")]
        public KinderGarten KinderGarten { get; set; }

    }
}
