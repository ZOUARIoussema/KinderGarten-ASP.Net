using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class userauthenticated
    {
        public string name { get; set; }
        public IList<string> authorities { get; set; }
        public string token { get; set; }

        public string username { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{name: " + name + ",");
            sb.Append("authorities: [");
            foreach (string row in authorities)
            {
                sb.Append(row.ToString());
            }
            sb.Append("]}");

            return sb.ToString();
        }

    }
}
