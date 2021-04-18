using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class SessionVote
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [JsonProperty("dateStart")]
        public DateTime DateStart { get; set; }
        [JsonProperty("dateEnd")]
        [DataType(DataType.Date)]
        public DateTime DateEnd { get; set; }
        [JsonProperty("winner")]
        public String Winner { get; set; }
        public List<Vote> ListVote { get; set; }



    }
}
