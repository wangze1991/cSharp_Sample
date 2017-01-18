using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// 枚举的另一种实现方式
    /// </summary>
    public class EnumExample
    {

        public static readonly EnumExample INVENTOR = new EnumExample(1, "发明人");

        /// <summary>
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        private EnumExample(int code, string name)
        {

            this.FieldName = name;
            this.FieldCode = code;
        }

        public int FieldCode { get; private set; }
        public string FieldName { get; private set; }
    }
}
