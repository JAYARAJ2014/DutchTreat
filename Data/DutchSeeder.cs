using System.Collections.Generic;
using System.IO;
using System.Linq;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext _context;
        private readonly IWebHostEnvironment _host;

        public DutchSeeder(DutchContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host; 
        }

        public void Seed()
        {
            _context.Database.EnsureCreated();

            if (!_context.Products.Any())
            {
                    var filePath  = Path.Combine(_host.ContentRootPath , "Data/art.json");
                    var json = File.ReadAllText(filePath);
                    var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

                    _context.Products.AddRange(products);

                    var order = _context.Orders.Where(o=>o.Id==1).FirstOrDefault();
                    if(order!=null )
                    {
                        order.Items= new List<OrderItem>() 
                        {
                              new OrderItem()  {
                                  Product = products.First(),
                                  Quantity = 5,
                                  UnitPrice = products.First().Price 
                              }            
                        };
                    }
                    _context.SaveChanges();
            }
        }
    }
}