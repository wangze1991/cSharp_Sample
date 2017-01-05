using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器模式
{
    public class Person:IFriendEnumable<Friend>
    {
        public IList<Friend> Friends { get; set; }

        public Person() {
            this.Friends = new List<Friend>();
        }
        public Iterator<Friend> GetEnumerator()
        {
            return new ConcreteIterator<Friend>(this.Friends);
        }
    }
}
