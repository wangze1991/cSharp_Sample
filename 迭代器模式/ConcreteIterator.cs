using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    public class ConcreteIterator<T>:Iterator<T>
    {
        private IList<T> _list;
        private int index;
        public ConcreteIterator(IList<T> list)
        {
            _list = list;
            index = 0;
        }

        public T Current
        {
            get;
            private set;
        }

        public bool MoveNext()
        {
            var isValid = index + 1 <= _list.Count;
            if (isValid)
            {
                Current = _list[index];
                index++;
            }
            return isValid;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}
