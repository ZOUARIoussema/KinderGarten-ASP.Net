using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class MedicalVisitKinderGarten
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public User Doctor { get; set; }

    }
}
