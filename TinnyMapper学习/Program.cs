using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nelibur.ObjectMapper.Mappers;
using Nelibur.ObjectMapper;
using System.ComponentModel;
using System.Globalization;
namespace TinnyMapper学习
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new PersonDto()
            {
                Id = 1,
                Email = "aa.com",
                Name = "bbbb"
            };
            var person = TinyMapper.Map<Person>(p);
            Console.WriteLine("映射");
            Console.ReadKey();
        }
    }

    public class Person {
        public int Id { get; set; }

        public string Email { get; set; }


        public string Name { get; set; }


        public DateTime CreateTime { get; set; }


        public DateTime UpdateTime { get; set; }
    
    }
    public class PersonDto{
        public int Id { get; set; }

        public string Email { get; set; }


        public string Name { get; set; }
    }



    public sealed class SourceClassConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(PersonDto);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var concreteValue = (Person)value;
            var result = new PersonDto
            {
                
            };
            return result;
        }
    }
}
