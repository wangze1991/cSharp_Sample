using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 窗体应用程序学习
{
    public partial class ComponentMy : Component
    {
        public ComponentMy()
        {
            InitializeComponent();
        }

        public ComponentMy(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
