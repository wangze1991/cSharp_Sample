using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Office
{
    /// <summary>
    /// Excel所在行(EasyUi)
    /// </summary>
    public class Column
    {
        //private string _title;
        //private string _field;
        private int _colspan;
        private int _rowspn;
        //private bool hidden;
        /// <summary>
        /// Column Title
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Column Field
        /// </summary>
        public string field { get; set; }

        /// <summary>
        /// colspan
        /// </summary>
        public int colspan
        {
            get
            {
                if (_colspan == 0) return 1;
                return _colspan;
            }
            set
            {
                _colspan = value;
            }
        }
        /// <summary>
        /// rowspan
        /// </summary>
        public int rowspan
        {
            get
            {
                if (_rowspn == 0) return 1;
                return _rowspn;
            }
            set
            {
                _rowspn = value;
            }
        }

        public bool hidden;
    }
}
