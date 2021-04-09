using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FolderMedical
    {
        public int Id { get; set; }
        public DateTime DateC { get; set; }
        public String Allergy { get; set; }
        public String Particularity { get; set; }
        public Child Child { get; set; }
        public List<Consultation> LisConsultations { get; set; }
        public List<ChildVaccine> LisChildVaccines { get; set; }
        public List<ChildVaccine> ListVaccinesToDo { get; set; }

    }
}
