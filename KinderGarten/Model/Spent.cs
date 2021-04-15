using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("total")]
        public double Total { get; set; }
        [JsonProperty("typeSepent")]
        public TypeSepent TypeSepent { get; set; }
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
