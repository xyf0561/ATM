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
    public partial class Operating : Form
    {
        string Number;
        string PIN;

        public Operating(string Number,string PIN)      //构造函数，2个参数
        {
            InitializeComponent();
            this.Number = Number;
            this.PIN = PIN;
            hidePanel();
        }
        

        public void hideButton()        //隐藏功能按钮
        {
            queryButton.Hide();
            transferButton.Hide();
            changePasswordButton.Hide();
            depositButton.Hide();
            withdrawalButton.Hide();
            exitButton.Hide();
        }

        public void showButton()        //显示功能按钮
        {
            queryButton.Show();
            transferButton.Show();
            changePasswordButton.Show();
            depositButton.Show();
            withdrawalButton.Show();
            exitButton.Show();
        }

        public void hidePanel()
        {
            Qpanel.Hide();
            Tpanel.Hide();
            Cpanel.Hide();
            Dpanel.Hide();
            Wpanel.Hide();
        } 

        private void queryButton_Click(object sender, EventArgs e)      //查询余额
        {
            double temp;

            Qpanel.Show();
            hideButton();
            string constr = "server=localhost;User Id=root;password=919881;Database=atm";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("SELECT  Abalance FROM account WHERE account.Anum = " + Number, mycon);
            MySqlDataReader reader = mycmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.HasRows)
                {
                    temp = (double)reader["Abalance"];
                    QLabel.Text = "余额：" + temp;
                }
            }
            reader.Close();
            mycon.Close();
        }
        

        private void changePasswordButton_Click(object sender, EventArgs e)     //修改密码
        {
            hideButton();
            Cpanel.Show();
        }
        private void exitButton_Click(object sender, EventArgs e)       //退出按钮
        {
            this.Close();
            ATM ATM = new ATM();
            ATM.Show();
        }

        private void QButton_Click(object sender, EventArgs e)
        {
            hidePanel();
            showButton();
        }

        private void PButton1_Click(object sender, EventArgs e)
        {
            hidePanel();
            string newPIN = CtextBox.Text;

            string constr = "server=localhost;User Id=root;password=919881;Database=atm";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("UPDATE account SET Apin = '" +newPIN +"'WHERE Anum = '" + Number+"'", mycon);
            mycmd.ExecuteNonQuery();
            mycon.Close();

            Qpanel.Show();
            QLabel.Text = "修改成功";
        }

        private void PButton2_Click(object sender, EventArgs e)
        {
            hidePanel();
            showButton();
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            hideButton();
            Dpanel.Show();
        }

        private void Dbutton1_Click(object sender, EventArgs e)
        {
            hidePanel();
            double plus = Convert.ToDouble(DtextBox.Text);
            string constr = "server=localhost;User Id=root;password=919881;Database=atm";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("SELECT Abalance FROM account WHERE Anum = '" + Number+"'", mycon);
            MySqlDataReader reader = mycmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.HasRows)
                {
                    plus = (double)reader["Abalance"]+plus;
                }
            }
            reader.Close();
            mycmd = new MySqlCommand("UPDATE account SET Abalance = '"+plus +"'WHERE Anum = '" + Number + "'", mycon);
            mycmd.ExecuteNonQuery();

            mycon.Close();

            Qpanel.Show();
            QLabel.Text = "存款成功";
        }

        private void Dbutton2_Click(object sender, EventArgs e)
        {
            hidePanel();
            showButton();
        }

        private void withdrawalButton_Click(object sender, EventArgs e)
        {
            hideButton();
            Wpanel.Show();
        }

        private void Wbutton1_Click(object sender, EventArgs e)
        {
            hidePanel();
            double reduce = Convert.ToDouble(WtextBox.Text);
            string constr = "server=localhost;User Id=root;password=919881;Database=atm";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("SELECT Abalance FROM account WHERE Anum = '" + Number + "'", mycon);
            MySqlDataReader reader = mycmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.HasRows)
                {
                    reduce = (double)reader["Abalance"] - reduce;
                }
            }

            if(reduce < 0)
            {
                reader.Close();
                mycon.Close();
                Qpanel.Show();
                QLabel.Text = "余额不足";
            }
            else
            {
                reader.Close();
                mycmd = new MySqlCommand("UPDATE account SET Abalance = '" + reduce + "'WHERE Anum = '" + Number + "'", mycon);
                mycmd.ExecuteNonQuery();
                mycon.Close();
                Qpanel.Show();
                QLabel.Text = "取款成功";
            }
        }

        private void Wbutton2_Click(object sender, EventArgs e)
        {
            hidePanel();
            showButton();
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            hideButton();
            Tpanel.Show();
        }

        private void Tbutton1_Click(object sender, EventArgs e)
        {
            hidePanel();
            string toID = TtextBox1.Text;
            double reduce = Convert.ToDouble(TtextBox2.Text);
            double balance1 = 0;
            double balance2 = 0;
            string constr = "server=localhost;User Id=root;password=919881;Database=atm";
            MySqlConnection mycon = new MySqlConnection(constr);
            mycon.Open();
            MySqlCommand mycmd = new MySqlCommand("SELECT Abalance FROM account WHERE Anum = '" + Number + "'", mycon);
            MySqlDataReader reader = mycmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader.HasRows)
                {
                    balance1 = (double)reader["Abalance"] - reduce;
                }
            }
            if (balance1 < 0)
            {
                reader.Close();
                mycon.Close();
                Qpanel.Show();
                QLabel.Text = "余额不足";
            }
            else
            {
                reader.Close();
                mycmd = new MySqlCommand("UPDATE account SET Abalance = '" + balance1 + "'WHERE Anum = '" + Number + "'", mycon);
                mycmd.ExecuteNonQuery();

                mycmd = new MySqlCommand("SELECT Abalance FROM account WHERE Anum = '" + toID + "'", mycon);
                reader = mycmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        balance2 = (double)reader["Abalance"] + reduce;
                    }
                }
                reader.Close();
                mycmd = new MySqlCommand("UPDATE account SET Abalance = '" + balance2 + "'WHERE Anum = '" + toID + "'", mycon);
                mycmd.ExecuteNonQuery();
                mycon.Close();
                Qpanel.Show();
                QLabel.Text = "转账成功";
            }

        }

        private void Tbutton2_Click(object sender, EventArgs e)
        {
            showButton();
            hidePanel();
        }
    }
}
