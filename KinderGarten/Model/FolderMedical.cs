using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Date)]
        public DateTime DateC { get; set; }
        [JsonProperty("allergy")]
        [Required]
        public String Allergy { get; set; }
        [JsonProperty("particularity")]
        [Required]
        public String Particularity { get; set; }
        [JsonProperty("child")]
        public Child Child { get; set; }
         
        public int? ChildId { get; set; }
        public int VaccineId { get; set; }
        [JsonProperty("lisConsultations")]
        public List<Consultation> LisConsultations { get; set; }
        [JsonProperty("lisChildVaccines")]
        public List<ChildVaccine> LisChildVaccines { get; set; }
        [JsonProperty("listVaccinesToDo")]
        public List<ChildVaccine> ListVaccinesToDo { get; set; }


        

    }
}
