using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class MedicalVisitKinderGarten
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("dateStart")]
        public DateTime DateStart { get; set; }
        [JsonProperty("dateEnd")]
        public DateTime DateEnd { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("themeColor")]
        public String ThemeColor { get; set; }
        [JsonProperty("isFullDay")]
        public Boolean IsFullDay { get; set; }

        [JsonProperty("subject")]
        public String Subject { get; set; }

        [JsonProperty("doctor")]
        public User Doctor { get; set; }

        public override string ToString()
        {
            return "id: " + Id + " Date s: " + DateStart + " Date end : " + DateEnd +
                " Description " + Description + " ThemeColor " + ThemeColor + " IsFullDay " + IsFullDay + " Subject " + Subject;
        }
    }
}
