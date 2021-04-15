using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class Publication
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public int NumberLike { get; set; }
        public int NumberDislike { get; set; }
        public String Attachment { get; set; }
        public User Parent { get; set; }
        public List<Comment> ListComments { get; set; }
        public List<Reaction> LisReactions { get; set; }



    }
}
