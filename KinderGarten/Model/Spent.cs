using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum TypeSepent
    {
        purchase, salary
    }

   public class Spent
    {

        public int Id { get; set; }
        public String Description { get; set; }
        public double Total { get; set; }
        public TypeSepent TypeSepent { get; set; }
        public DateTime DateC { get; set; }
        public User AgentCashier { get; set; }
    }
}
