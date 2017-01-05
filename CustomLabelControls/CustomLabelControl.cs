using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomLabelControls
{
    public partial class CustomLabelControl : UserControl
    {
        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Bindable(true)]   //不加这个，无法在设计器中直接设置Text
        public override string Text { get; set; }
        public CustomLabelControl()
        {
            InitializeComponent();
        }
    }
}
