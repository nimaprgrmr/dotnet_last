using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop2.Models
{
    public class DetailsBuy
    {
        // id product s
        // id buys 
        // public int ID { get; set; }
        public int Count { get; set; }
        public int TPrice { get; set; } // Count * FPrice
        // rel -> m:n (*:*) ---> 1:n & 1:m
        public virtual Buy buy { get; set; } // Key Main
        public int BuyID { get; set; }
        public virtual Product product { get; set; }
        public int ProductID { get; set; } // Key Main
    }
}
