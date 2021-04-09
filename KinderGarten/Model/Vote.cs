using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
     public class Vote
    {
        public int Id { get; set; }
        public User Voter { get; set; }
        public User VotedFor { get; set; }
        public DateTime DateVote { get; set; }
        public SessionVote SessionVote { get; set; }



    }
}
