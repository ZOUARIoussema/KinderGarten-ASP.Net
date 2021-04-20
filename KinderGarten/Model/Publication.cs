using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Model
{
  public  class Publication
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("description")]
        public String Description { get; set; }
        [JsonProperty("numberLike")]
        public int NumberLike { get; set; }
        [JsonProperty("numberDislike")]
        public int NumberDislike { get; set; }
        [JsonProperty("attachment")]
        public String Attachment { get; set; }
        [JsonProperty("parent")]
        public User Parent { get; set; }
        [JsonProperty("listComments")]
        public List<Comment> ListComments { get; set; }
        [JsonProperty("lisReactions")]
        public List<Reaction> LisReactions { get; set; }



    }
}
