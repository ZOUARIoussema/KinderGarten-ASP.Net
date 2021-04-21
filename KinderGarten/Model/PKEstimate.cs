using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class PKEstimate
    {
        [JsonProperty("idUser")]
        public int IdUser { get; set; }
        [JsonProperty("idKinder")]
        public int IdKinder { get; set; }
        [JsonProperty("dateC")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateC { get; set; }


    }
}
