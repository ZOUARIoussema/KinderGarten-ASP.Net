using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum RoleSwitch {

        futureParent, adminGarten

    }

   public class SwitchAccount
    {
        public int Id { get; set; }
        public DateTime DateC { get; set; }
        public String State { get; set; }
        public RoleSwitch RoleSwitch { get; set; }
        public User Visitor { get; set; }


    }
}
