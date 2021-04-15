using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Category
    {

        public int Id { get; set; }
        public String Description { get; set; }
        public KinderGarten KinderGarten { get; set; }
        public List<Event> LisEvents { get; set; }
        public List<Club> ListClubs { get; set; }
        public List<Child> ListChild { get; set; }




    }
}
