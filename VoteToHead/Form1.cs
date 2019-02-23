using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VoteToHead
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            txtUserName.GotFocus += new EventHandler(this.TextGotFocus);
            txtUserName.LostFocus += new EventHandler(this.TextLostFocus);

            txtPwd.GotFocus += new EventHandler(this.PwdGotFocus);
            txtPwd.LostFocus += new EventHandler(this.PwdLostFocus);
        }

        public void TextGotFocus(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;
            if (tb.Text == "User Name")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        public void TextLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "User Name";
                tb.ForeColor = Color.Gray;
            }
        }

        public void PwdGotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "Password")
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }

        public void PwdLostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "Password";
                tb.ForeColor = Color.Gray;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login form cLosed!");
                {
            }
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "Admin" && txtPwd.Text == "admin")
            {
                this.Hide();

                Form3 f3 = new Form3();
                f3.Show();
                MessageBox.Show("Login sucessfully done!", "Message");
            }

            else if (txtUserName.Text == "Student" && txtPwd.Text == "12345")
            {
                Form2 f2 = new Form2();
                this.Hide();
                f2.Show();
                MessageBox.Show("Login Sucessfully done!", "Message");
            }
            else MessageBox.Show("Error! Invalid UserName or Password", "Error");
        }
    }
}
