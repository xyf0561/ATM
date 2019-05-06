using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ATM
{
    public partial class ATM : Form
    {
        public ATM()        //创建对象
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string Number = numberText.Text;
            string Apin = null;
            string PIN = pinText.Text;
            bool query = false;     //数据库中是否存在

            string constr = "server=localhost;User Id=root;password=919881;Database=atm";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("SELECT  Apin FROM account WHERE account.Anum = " + Number, mycon);
            MySqlDataReader reader = mycmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.HasRows)
                {
                    Apin = (string)reader["Apin"];
                    query = true;     //数据库中存在
                }
            }
                
            else
            {
                informationLabel.Text = "查询账户失败，请重试";     //数据库中不存在
                numberText.Text = "";
                pinText.Text = "";
            }

            
            if(query)
            {
                if (Apin.Equals(PIN) == true)
                {
                    this.Hide();
                    Operating Operating = new Operating(Number, PIN);
                    Operating.Show();       //打开操作界面的新窗口
                }
                else
                {
                    informationLabel.Text = "输入密码错误，请重试";
                    numberText.Text = "";
                    pinText.Text = "";      //清空对话框，要求重新输入
                }
            }
            reader.Close();
            mycon.Close();      //关闭数据库
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
