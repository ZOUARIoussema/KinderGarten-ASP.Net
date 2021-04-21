using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Estimate
    {

        [JsonProperty("pkEstimate")]
        public PKEstimate PkEstimate { get; set; }
        [JsonProperty("provider")]
        public User Provider { get; set; }
        [JsonProperty("kGarten")]
        public KinderGarten KGarten { get; set; }
        [JsonProperty("item")]
        [Display(Name = "Product")]
        [Required(ErrorMessage = "Required fields")]
        [StringLength(25, ErrorMessage = "taille max=25")]
        [MaxLength(50)]
        public String Item { get; set; }
        [JsonProperty("qte")]
        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Required fields")]
        public int Qte { get; set; }
        [JsonProperty("total")]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Required fields")]
        public double Total { get; set; }

    }
}
