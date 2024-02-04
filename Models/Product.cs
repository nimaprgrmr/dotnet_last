using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Eshop2.Models
{
    public class Product
    {
        public int ID { get; set; }
        public ProductType Types { get; set; }
        public enum ProductType{
            mobile, laptop, tablet, watch, others
        }

        public string Title { get; set; }

        public string Description {get; set;}

        public int Count { get; set; }

        public int FPrice { get; set; }
        public bool Isdeleted { get; set; }
        public virtual List<Comment> comments { get; set; }
        public virtual List<DetailsBuy> detailsbuy { get; set; }
    }
}