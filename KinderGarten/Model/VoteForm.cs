using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class VoteForm
    {
        public int Id { get; set; }
        public int Voter { get; set; }
        public int VotedFor { get; set; }

    }
}
