using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CarsDB
{
    public partial class ServiceCreate : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public ServiceCreate()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod;
            string nameService = textBox2.Text;
            string nameCompany = textBox3.Text;
            string description = textBox4.Text;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление");
                return;
            }
            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                string query = "INSERT INTO ДопУслуги (КодУслуги, НазваниеУслуги, НазваниеКомпании, Описание) VALUES (" + kod + ",'" + nameService + "', '" + nameCompany + "', '" + description + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }

        private void ServiceCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
