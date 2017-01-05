using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrmBaiduDictionary.Common;
using FrmBaiduDictionary.Data;
using Utils;

namespace FrmBaiduDictionary
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            this.btnQuery.Click += BtnQuery_Click;
        }

        /// <summary>
        /// 点击查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void BtnQuery_Click(object sender, EventArgs e)
        {
            var queryWord = txtWord.Text;
            if (!IsValid(queryWord))
            {
                MessageBox.Show("请输入要查询的单词", "提示", MessageBoxButtons.RetryCancel);
                return;
            }
            Word word = new Word(queryWord);
            var json = await WebClientHelper.GetWebHtml(word.ToUrl());
            var list = json.DeserializeJson<BaiDuWord>();
            if (list.data != null && list.data.symbols != null & list.data.symbols.Any())
            {
                this.lblResult.Text = list.data.symbols[0].parts[0].means[0];
            }
         
        }
        bool IsValid(string word)
        {
            return !string.IsNullOrEmpty(word);
        }


    }
}
