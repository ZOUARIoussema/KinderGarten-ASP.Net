using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class Event
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [JsonProperty("nParticipate")]
        public int NParticipate { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [JsonProperty("object")]
        public String Object { get; set; }
        [JsonProperty("category")]
        public Category Category { get; set; }


    }
}
