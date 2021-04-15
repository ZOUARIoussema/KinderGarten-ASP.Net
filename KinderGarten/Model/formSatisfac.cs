using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class formSatisfac
    {
        public int Id { get; set; }
        public DateTime Date_debut { get; set; }
        public DateTime Date_fin { get; set; }
        public int Nbr_reponses { get; set; }
        public User ParentStatisfac { get; set; }

    }
}
