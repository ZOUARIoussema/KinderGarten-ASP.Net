using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class Consultation
    {
        public int Id { get; set; }
        public DateTime DateC { get; set; }
        public String Description { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public User Doctor { get; set; }
        public FolderMedical FolderMedical { get; set; }

    }
}
