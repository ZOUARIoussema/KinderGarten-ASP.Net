using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class Message
    {
        public long Id { get; set; }
        public String Content { get; set; }
        public DateTime Date { get; set; }
        public User FromUser { get; set; }
        public User ToUser { get; set; }

    }
}
