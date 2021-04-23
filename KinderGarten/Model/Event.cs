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
        [Required(ErrorMessage = "Required fields")]
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        [JsonProperty("date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Required fields")]
        public DateTime Date { get; set; }
        [JsonProperty("nParticipate")]
        public int NParticipate { get; set; }
        [JsonProperty("price")]
        [Required(ErrorMessage = "Required fields")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [JsonProperty("object")]
        [StringLength(25, ErrorMessage = "taille max=25")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Required fields")]
        [Display(Name = "Product Need It")]
        public String Object { get; set; }
        [JsonProperty("category")]
        public Category Category { get; set; }
        public int? CategoryId { get; set; }


    }
}
