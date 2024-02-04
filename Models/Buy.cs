using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop2.Models
{
    public class Buy
    {
        // Id details buy 
        // id account 
        public int ID { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public virtual Account account { get; set; }
        public int AccountID { get; set; }
        public virtual List<DetailsBuy> detailsbuy { get; set;}
    }
}