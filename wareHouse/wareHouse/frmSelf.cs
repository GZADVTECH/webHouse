﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wareHouse
{
    public partial class frmSelf : Form
    {
        private string ID;
        public frmSelf()
        {
            InitializeComponent();
        }
        public frmSelf(string id)
        {
            InitializeComponent();
            ID = id;
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证是否为空
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    if (string.IsNullOrEmpty(item.Text))
                    {
                        MessageBox.Show("不允许为空！");
                        return;
                    }
                }
            }
            //判断新密码与重复新密码是否一致
            if (txtNewPwd.Text!=txtRePwd.Text)
            {
                MessageBox.Show("密码不一致");
            }
            //判断旧密码是否正确，如果正确，将进行修改密码操作
            if ((WHBLL.BLL.GetLogin(txtUid.Text, txtOldPwd.Text).Rows.Count > 0))
            {
                if (WHBLL.BLL.UpdatePwd(txtUid.Text, txtNewPwd.Text) > 0)
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("修改失败，请稍后再试！");
                }
            }
            else
                MessageBox.Show("密码错误！");
        }

        private void frmSelf_Load(object sender, EventArgs e)
        {
            txtUid.Text = ID;
        }
    }
}
