using Alexander_Fearday_Unit2_IT481;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alex_Fearday_Unit2_IT481
{
    public partial class Form1 : Form
    {
        DB database;
        private string user;
        private string password;
        private string server;
        private string databaseString;

        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);
            button4.Click += new EventHandler(button4_Click);
            button5.Click += new EventHandler(button5_Click);
            button6.Click += new EventHandler(button6_Click);
            button7.Click += new EventHandler(button7_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            user = textBox1.Text;
            password = textBox2.Text;
            server = textBox3.Text;
            databaseString = textBox4.Text;

            if (user.Length == 0 || password.Length == 0 || server.Length == 0 || databaseString.Length == 0)
            {
                isValid = false;
                MessageBox.Show("You must enter username, password, server, and database values");
            }

            else if(password.Length < 12)
            {
                isValid = false;
                MessageBox.Show("Password Length must be 12 characters or more");
            }
            else
            {
                if(password.All(char.IsLetterOrDigit) && password.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    isValid = false;
                    MessageBox.Show("You must enter alphanumric and special characters for the password");
                }
            }
            
            if (isValid)
            {
                database = new DB("Server = " + server + "\\SQLEXPRESS; " +
                                       "Trusted_Connection=true;" +
                                      "Database = " + database + ";" +
                                      "User Id = " + user + ";" +
                                      "Password = " + password + ";");
                MessageBox.Show("Connection information was sent.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string count = database.getCustomerCount();
            MessageBox.Show(count, "Customer count");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string names = database.getCustomerName();
            MessageBox.Show(names, "Customer Names");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string count = database.getOrderCount();
            MessageBox.Show(count, "Order Count");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string orderid = database.getOrders();
            MessageBox.Show(orderid, "Order ID");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string count = database.getEmployeeCount();
            MessageBox.Show(count, "Employee Count");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string names = database.getEmployeeLastName();
            MessageBox.Show(names, "Employees Last Names");
        }
    }
}
