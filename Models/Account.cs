using EntityFrameworkCore.EncryptColumn.Attribute;
using NetTopologySuite.Geometries;

namespace Eshop2.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Username { get; set; }
        [EncryptColumn]
        public string Password { get; set; }
        public string NameFamily { get; set; }
        public string Email { get; set; }
        // [RegularExpression("/((0?9)|(\\+?989))\\d{2}\\W?\\d{3}\\W?\\d{4}/g")]
        public int PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        // [RegularExpression("\b(?!(\\d)\\1{3})[13-9]{4}[1346-9][013-9]{5}\b")]
        public int PostCode { get; set; }
        public Point Location { get; set; }
        // Rel ---> 1-1
        public virtual Others other { get; set; }
        // Rel ---> 1-n
        public virtual List<Comment> comments { get; set; }
        public virtual List<Buy> buys{ get; set; }
        public virtual List<DetailsBuy> detailsbuy { get; set; }
    }
}
