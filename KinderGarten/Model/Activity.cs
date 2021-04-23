using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Activity
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("description")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Required fields")]
        public String Description { get; set; }
        [JsonProperty("photo")]
        public String Photo { get; set; }
        [JsonProperty("kinderGarten")]
        public KinderGarten KinderGarten { get; set; }


    }
}
