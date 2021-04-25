using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ChildVaccine
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [JsonProperty("monthNumber")]
        public int MonthNumber { get; set; }
        [Required]
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("lisFolderMedicals")]
        public List<FolderMedical> LisFolderMedicals { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ChildVaccine vaccine &&
                   Id == vaccine.Id;
        }
    }
}
