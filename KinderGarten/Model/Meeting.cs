using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Meeting
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required fields")]
        [JsonProperty("dateStart")]
        public DateTime DateStart { get; set; }
        [JsonProperty("dateEnd")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required fields")]
        public DateTime DateEnd { get; set; }
        [JsonProperty("kinderGarten")]
        public KinderGarten KinderGarten { get; set; }  
    }
}
