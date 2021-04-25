using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Claim
    {

        public int Id { get; set; }
        public String Objet { get; set; }
        public String Description { get; set; }
        public String Type { get; set; }
        public String State { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Creation_date { get; set; }
        public User Parent { get; set; }




    }
}
