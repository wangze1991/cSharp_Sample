﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    public class CalculateTax:ICalculateTax
    {

        public decimal GetTax(Wage wage)
        {
            throw new NotImplementedException();
        }
    }
}
