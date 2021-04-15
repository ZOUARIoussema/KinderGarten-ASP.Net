using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FolderMedical
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("dateC")]
        public DateTime DateC { get; set; }
        [JsonProperty("allergy")]
        public String Allergy { get; set; }
        [JsonProperty("particularity")]
        public String Particularity { get; set; }
        [JsonProperty("child")]
        public Child Child { get; set; }
        public int? ChildId { get; set; }
        public List<Consultation> LisConsultations { get; set; }
        public List<ChildVaccine> LisChildVaccines { get; set; }
        public List<ChildVaccine> ListVaccinesToDo { get; set; }

    }
}
