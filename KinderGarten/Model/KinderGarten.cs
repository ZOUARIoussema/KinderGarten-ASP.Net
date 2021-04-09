using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KinderGarten
    {

         public int Id { get; set; }
         public String Name { get; set; }
         public String  Adress { get; set; }
         public String Email { get; set; }
        public int Tel { get; set; }
        public int ScoreEval { get; set; }
        public String Logo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<User> ListParent { get; set; }
        public List<Activity> ListActivity { get; set; }
        public List<Extra> ListExtra { get; set; }
        public List<CategorySubscription> ListCategoryS { get; set; }
        public List<Meeting> ListMeeting { get; set; }
        public List<Category> ListCategory { get; set; }
        public User Delegate { get; set; }
        public User Responsible { get; set; }





    }
}
