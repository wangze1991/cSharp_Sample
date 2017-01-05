using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    /// <summary>
    /// 迭代器接口
    /// </summary>
    public interface Iterator<T> 
    {
    
        T Current { get; }

        bool MoveNext();

        void Reset();
    }
}
