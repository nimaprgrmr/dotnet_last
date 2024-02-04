using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop2.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public int Point { get; set; }
        public virtual Account account { get; set; }
        public int AccountID { get; set; }
        public virtual Product product { get; set; }
        public int ProductID { get; set; }
    }
}