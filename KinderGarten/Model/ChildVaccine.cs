using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ChildVaccine
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("monthNumber")]
        public int MonthNumber { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("lisFolderMedicals")]
        public List<FolderMedical> LisFolderMedicals { get; set; }


    }
}
