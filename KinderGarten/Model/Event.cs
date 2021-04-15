using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class Event
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public DateTime Date { get; set; }
        public int NParticipate { get; set; }
        public double Price { get; set; }
        public String Object { get; set; }
        public Category Category { get; set; }


    }
}
