using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    public interface ICalculateTax
    {
        /// <summary>
        ///计算个税
        /// </summary>
        /// <returns></returns>
        decimal GetTax(Wage wage);
    }
}
