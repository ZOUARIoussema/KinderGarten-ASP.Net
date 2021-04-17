using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public String Name { get; set; }
        [JsonProperty("adress")]
        public String Adress { get; set; }
        [JsonProperty("email")]
        public String Email { get; set; }
        [JsonProperty("tel")]
        public int Tel { get; set; }
        [JsonProperty("scoreEval")]
        public float ScoreEval { get; set; }
        [JsonProperty("logo")]
        public String Logo { get; set; }
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
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
