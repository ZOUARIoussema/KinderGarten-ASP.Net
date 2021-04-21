using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KinderGarten
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        [Required(ErrorMessage = "Required fields")]
        [StringLength(25, ErrorMessage = "taille max=25")]
        [MaxLength(50)]
        public String Name { get; set; }
        [JsonProperty("adress")]
        [Required(ErrorMessage = "Required fields")]
        [StringLength(25, ErrorMessage = "taille max=25")]
        [MaxLength(50)]
        public String Adress { get; set; }
        [JsonProperty("email")]
        [Required(ErrorMessage = "Required fields")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [JsonProperty("tel")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Required fields")]
        [Display(Name = "PhoneNumber")]
        public int Tel { get; set; }
        [JsonProperty("scoreEval")]
        public float ScoreEval { get; set; }
        [JsonProperty("logo")]
        public String Logo { get; set; }
        [JsonProperty("latitude")]
        [Required(ErrorMessage = "Required fields")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        [Required(ErrorMessage = "Required fields")]
        public double Longitude { get; set; }

        public List<User> ListParent { get; set; }
        public List<Activity> ListActivity { get; set; }
        public List<Extra> ListExtra { get; set; }
        public List<CategorySubscription> ListCategoryS { get; set; }
        public List<Meeting> ListMeeting { get; set; }
        public List<Category> ListCategory { get; set; }
        [JsonProperty("delegate")]
        public User Delegate { get; set; }
        [JsonProperty("responsible")]
        public User Responsible { get; set; }





    }
}
