using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Notice
    {
        public int Id { get; set; }
        public DateTime DateC { get; set; }
        public int Score { get; set; }
        public User Parent { get; set; }

    }
}
