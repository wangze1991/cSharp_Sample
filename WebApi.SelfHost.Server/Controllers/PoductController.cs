using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.SelfHost.Server.Models;

namespace WebApi.SelfHost.Server.Controllers
{
    public class ProductController:ApiController
    {

        private static readonly IEnumerable<Product> _products;

        static ProductController() {
            _products = new List<Product>() {
                new Product(){ Id=1,Price=100,ProductName="ToFu"},
                new Product(){Id=2,Price=200,ProductName="Clothes"},
                new Product(){Id=3,Price=0.5m,ProductName="辣条"}
            };
        }

        public Product Get(int id=1)
        {
            return _products.FirstOrDefault(x =>x.Id==id);
        }
    }
}
