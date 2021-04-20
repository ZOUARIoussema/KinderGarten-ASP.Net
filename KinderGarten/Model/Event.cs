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
        [DataType(DataType.MultilineText)]
        [Required]
        public String Description { get; set; }
        [JsonProperty("date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }
        [JsonProperty("nParticipate")]
        public int NParticipate { get; set; }
        [JsonProperty("price")]
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        [JsonProperty("object")]
        [Required, MaxLength(50, ErrorMessage = "length not respected"), StringLength(25, ErrorMessage = "string length not respected"), Display(Name = "Produit")]
        public String Object { get; set; }
        [JsonProperty("category")]
        public Category Category { get; set; }
        public int? CategoryId { get; set; }


    }
}
