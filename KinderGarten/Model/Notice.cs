using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model
{
   public class Notice
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("dateC")]
        public DateTime DateC { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
        [JsonProperty("parent")]
        public User Parent { get; set; }

    }
}
