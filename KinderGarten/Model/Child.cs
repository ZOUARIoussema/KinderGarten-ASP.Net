using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Child
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime DateOfbith { get; set; }
        public String Sex { get; set; }
        public int Age { get; set; }
        public String Picture { get; set; }
        public double FidelityPoint { get; set; }
        public User Parent { get; set; }
        public List<SubscriptionChild> LisSubscriptionChilds { get; set; }
        public FolderMedical FolderMedical { get; set; }
        public List<Category> ListInterest { get; set; }
        public List<Event> LisEvents { get; set; }





    }
}
