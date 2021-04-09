using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Estimate
    {

        public PKEstimate PkEstimate { get; set; }
        public User Provider { get; set; }
        public KinderGarten KGarten { get; set; }
        public String Item { get; set; }
        public int Qte { get; set; }
        public double Total { get; set; }

    }
}
