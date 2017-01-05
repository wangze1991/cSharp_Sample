using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 委托的学习
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new User() {Id = "001", Name = "wangze",UserAddress = new Address(){City = "常州市",Province = "江苏省"}};
            Console.WriteLine(user.PropertyFor(x => x.UserAddress.Province));
            Console.ReadKey();
    
        }
    }

    public static class HtmlHelper
    {

        public static string PropertyFor<T, TProperty>(this T t, Func<T, TProperty> func)
            where T : class,new()
        {

            return func.Target.ToString();
        }

    }

    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Address UserAddress { get; set; }

        static User()
        {
        }


        public User()
        {
        }
    }

    public class Address
    {
        public string Province { get; set; }

        public string City { get; set; }
    }
}
