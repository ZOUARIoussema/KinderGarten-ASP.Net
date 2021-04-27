using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum TypeSepent
    {
        purchase, salary
    }

   public class Spent
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("description")]
        public String Description { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [JsonProperty("total")]
        public double Total { get; set; }
        [JsonProperty("type")]
        public TypeSepent TypeSepent { get; set; }
        [DataType(DataType.Date)]
        [JsonProperty("dateC")]
        public DateTime DateC { get; set; }
        [JsonProperty("agentCashier")]
        public User AgentCashier { get; set; }

        public override string ToString()
        {
            return "id: "+this.Id +"desc "+
                this.Description+"total "+this.Total+"type spent "+
                this.TypeSepent+"date c "+this.DateC;
        }
    }




}
