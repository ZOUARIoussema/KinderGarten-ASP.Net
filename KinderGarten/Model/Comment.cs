using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model
{
  public class Comment
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("parent")]
        public User Parent { get; set; }
        [JsonProperty("publication")]
        public Publication Publication { get; set; }



    }
}
