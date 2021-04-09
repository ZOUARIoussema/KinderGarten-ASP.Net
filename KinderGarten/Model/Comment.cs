using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public User Parent { get; set; }
        public Publication Publication { get; set; }



    }
}
