using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 模拟抽奖软件
{
    public partial class Form1 : Form
    {
        private Thread thread = null;
        private delegate void FlushClient();//代理
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnTrigger.Text = "开始";
        }

        private void btnTrigger_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Text.Equals("开始"))
            {
                if (thread == null)
                {
                    thread = new Thread(CrossThreadFlush);
                    thread.IsBackground = true;
                    thread.Start();
                }
                else
                {
                    thread.Start();
                }
                btn.Text = "结束";

            }
            else
            {
                if (thread != null)
                {
                    thread.Abort();
                    thread = null;
                }
                btn.Text = "开始";
            }

        }


        private void CrossThreadFlush()
        {
            Action actionDelegate = () =>
            {
                this.lblNumber.Text = new Random(Guid.NewGuid().GetHashCode()).Next(1000, 10000).ToString();
            };
            while (true)
            {
                Thread.Sleep(100);
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(actionDelegate);
                }
                else
                {
                    actionDelegate();
                }
      
            }
        }



    }
}
