using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum React
    {
        NONE, LIKE, LOVE, WOW, HAHA, SAD, ANGRY
    }

   public class Reaction
    {
        public ReactionPK LikePk { get; set; }
        public User User { get; set; }
        public Publication Publication { get; set; }
        public React React { get; set; }
        public DateTime Date { get; set; }



    }
}
