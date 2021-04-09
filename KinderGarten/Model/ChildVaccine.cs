using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ChildVaccine
    {
        public int Id { get; set; }
        public int MonthNumber { get; set; }
        public String Description { get; set; }
        public List<FolderMedical> LisFolderMedicals { get; set; }


    }
}
