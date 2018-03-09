using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace io_console_sample
{
    public class StreamTest
    {
        private string _str = "hello world";

        private readonly int[] array = { 1, 2, 3, 5 };

        public void test2()
        {
            array[1] = 9;
            array.ToList().ForEach(x => Console.WriteLine(x));
        }

        public void excute()
        {
            try
            {
                this.test2();
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}