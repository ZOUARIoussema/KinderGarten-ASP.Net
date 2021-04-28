using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model
{
    public class Child
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public String Name { get; set; }
        [JsonProperty("dateOfbith")]
        [DataType(DataType.Date)]
        public DateTime DateOfbith { get; set; }
        [JsonProperty("sex")]
        public String Sex { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("picture")]
        public String Picture { get; set; }
        [JsonProperty("fidelityPoint")]
        public double FidelityPoint { get; set; }
        [JsonProperty("parent")]
        public User Parent { get; set; }
        [JsonProperty("lisSubscriptionChilds")]
        public List<SubscriptionChild> LisSubscriptionChilds { get; set; }
        [JsonProperty("folderMedical")]
        public FolderMedical FolderMedical { get; set; }
        [JsonProperty("listInterest")]
        public List<Category> ListInterest { get; set; }
        [JsonProperty("lisEvents")]
        public List<Event> LisEvents { get; set; }

       
        





    }
}
