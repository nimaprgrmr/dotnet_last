using Eshop2.Datas;
using Eshop2.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System.Collections;
using System.Net;
using NetTopologySuite.Geometries;

using DBMain DB = new DBMain();
// var loc = new Point(15.3, 16.4);
// loc.SRID = 4326;

// var loc1 = new Point(20.3, 25.7);
// loc1.SRID = 4326;

// var p = new Account(){
//     PostCode = 25648,
//     Email = "test3@gmail.com",
//     PhoneNumber = 093545732,
//     City = "Yazd",
//     Address = "yazd",
//     // Location = loc,
//     Username = "Test3Username",
//     Password = "TestEst",
//     NameFamily = "ahmad shamloo"
// };
// var p1 = new Account(){
//     PostCode = 2154879,
//     Email = "test4@gmail.com",
//     PhoneNumber = 0939547854,
//     City = "Kermanshah",
//     Address = "KErmanshah, ghasre shirin",
//     // Location = loc1,
//     Username = "Test4Test",
//     Password = "Test4USerpass",
//     NameFamily = "Test4NameFamily"
// };
// DB.Accounts.Add(p);
// DB.SaveChanges();
// DB.Accounts.Add(p1);
// DB.SaveChanges();

// add others 
// DB.Others.Add(new Others(){
//     AccountID = 5,  // this should be a true account id, an exist account id.
//     Age = 53,
//     Sex = Others.SexType.male,
//     CodeNation = 25861125,
// });
// DB.SaveChanges();

// Add product to database 
// DB.Products.Add(new Product(){
//     Title = "Product 4",
//     Types = Product.ProductType.others,
//     Description = "Hard ss 256 G",
//     Count = 1,
//     FPrice = 1000000,
//     Isdeleted = true,
// });
// DB.SaveChanges();

// // Add Comment
// DB.Comments.Add(new Comment(){
//     AccountID = 4,  // this should be an exist AccountID and true value
//     ProductID = 3, // This shoudl be a real ProductID and true value 
//     Point = 2,
//     Text = "i think this item is very bad",
//     Title = "Bad",
//     Time = DateTime.Now,
// });
// DB.SaveChanges();

// DB.Buys.Add(new Buy(){
//     AccountID = 2,
//     Time = DateTime.Now,
//     Description = "Account 2 buying"
// });
// DB.SaveChanges();

// DB.DetailsBuys.Add(new DetailsBuy(){
//     BuyID = 5,
//     ProductID = 2,
//     TPrice = 2545700,
//     Count = 1,
// });
// DB.SaveChanges();

// var data = DB.Products.Where(x => x.ID == 4).First();
// System.Console.WriteLine(data.FPrice);
// DB.Accounts.Add(new Eshop2.Models.Account()
// {
//     Username = "alireza123",
//     Password = "12345667",
//     NameFamily = "aslireza bakhshande",
//     Email = "ali@gmail.com",
//     PhoneNumber = 0263449625,
//     PostCode = 123456,
//     City = "Karaj",
//     Address = "azimie",
// });

// DB.SaveChanges();


// DB.Accounts.Remove(new eShop.Models.Account() {ID = 6}); // for deleting phisically product which has ID = 6 
// var data = DB.Products.Where(x => x.ID == 14).First();  // dar in ravesh ma ad deleted logic estefade mikonim yani yek meghdar
// data.Count = 0;   // be esme is deleted ezafe kardim 
// DB.Products.Update(data); // va ba 1 kardane an neshan midahim ke in kala remove shode ast.

// DB.SaveChanges();

// var data = DB.Products.Where(x => x.Isdeleted != true).ToList();  // tabdile maghadiri ke Isdeleted anha 0 ast be list va namayeshe anha dar edame

// foreach (var item in data)
// {
//     System.Console.WriteLine($"title: {item.Title}, Count: {item.Count}");
// }

// var top3 = DB.Products.Where(x=> x.Count >0 && x.Isdeleted!=true).Take(3).ToList();  // in command 3 item avalie ke az sharayete dakahele Where peyravi mikonand ra take mikonad

// foreach (var item in top3)
// {
//     System.Console.WriteLine($"Product name: {item.Title}| Count: {item.Count}");    
// }

// var top3_with_skip = DB.Products.Where(x=> x.Count >0 && x.Isdeleted!=true).Skip(2).Take(3).ToList();  // in command 3 item avalie ke az sharayete dakahele Where peyravi mikonand ra take mikonad

// foreach (var item in top3_with_skip)
// {
//     System.Console.WriteLine($"Product name: {item.Title}| Count: {item.Count}");    
// }

// select with Include
// var list = DB.Accounts.Include(o=>o.other).ToList();

// foreach (var item in list)
// {
//     if (item.NameFamily == "TestUSerfamily"){
//         System.Console.WriteLine($"Age TestUSerfamily is: {item.other.Age}");
//     }
// }

// select query with include 
// var informations = DB.Accounts.Include(o=>o.other).Where(x=>x.NameFamily=="ahmad shamloo").FirstOrDefault();
// var age = informations.other.Age;
// System.Console.WriteLine(age);
 
// var inf = DB.Accounts.Include(a=>a.comments).Where(a=>a.Username == "Test3Username").FirstOrDefault();
// var coms = inf.comments;
// foreach (var item in coms)
// {
//     System.Console.WriteLine(item.Text);
// }

 // dar vaghe amalkarde include manande left join or right join ast va baraye etesal 2 table monaseb ast.
 // ama zamani ke bekhahim bishtar az 2 jadval ra beham rabt dahim az theninclude estefade mikonim

 var informations = DB.Accounts.Include(p=>p.comments).ThenInclude(o=>o.product).Where(p=>p.City=="Tehran");
 System.Console.WriteLine(informations);
