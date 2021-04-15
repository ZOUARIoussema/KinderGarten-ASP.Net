using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public enum TypePayement
    {
        onLine, bankCheck, cash
    }

   public class PayementSubscription
    {
        public int Id { get; set; }
        public DateTime DateC { get; set; }
        public double Price { get; set; }
        public TypePayement TypePayement { get; set; }
        public int CheckNumber { get; set; }
        public DateTime DateCheck { get; set; }
        public SubscriptionChild SubscriptionChild { get; set; }
        public User User { get; set; }



    }
}
