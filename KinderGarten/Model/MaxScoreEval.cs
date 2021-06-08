using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class MaxScoreEval
    {
        [JsonProperty("maxScore")]
        public double MaxScore { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }


        public override string ToString()
        {
            return "{ maxscore :" + MaxScore + ",name :" + Name + "}"; 
        }


    }
}
