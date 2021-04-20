using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class VoteForm
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("voter")]
        public int Voter { get; set; }
        [JsonProperty("votedFor")]
        public int VotedFor { get; set; }

    }
}
