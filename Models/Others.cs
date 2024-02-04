using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop2.Models
{
    public class Others
    {
        // public int ID { get; set; }
        public int CodeNation { get; set; }
        public int Age { get; set; }
        public SexType Sex { get; set; }
        public enum SexType
        {
            male, female, others = -1
        }
        // Rel ---> 1-1
        public virtual Account account { get; set; }
        public int AccountID { get; set; }
    }
}
