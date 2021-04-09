using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Claim
    {

        public int Id { get; set; }
        public String Object { get; set; }
        public String Description { get; set; }
        public String Type { get; set; }
        public String State { get; set; }
        public DateTime Creation_date { get; set; }
        public User Parent { get; set; }




    }
}
