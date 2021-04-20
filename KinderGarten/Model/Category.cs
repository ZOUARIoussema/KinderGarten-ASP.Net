using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Display(Name = "Categorie")]
        [Required]
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("kinderGarten")]
        public KinderGarten KinderGarten { get; set; }
        public List<Event> LisEvents { get; set; }
        public List<Club> ListClubs { get; set; }
        public List<Child> ListChild { get; set; }




    }
}
