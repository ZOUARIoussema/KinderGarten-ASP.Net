﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Extra
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public double Price { get; set; }
        public List<SubscriptionChild> ListSubscriptionChilds { get; set; }
        public KinderGarten KinderGarten { get; set; }

    }
}
