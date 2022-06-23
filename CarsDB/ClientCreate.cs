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
    public partial class ClientCreate : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public ClientCreate()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod;
            string surname = textBox2.Text;
            string name = textBox3.Text;
            string patronymic = textBox4.Text;
            string passport = textBox5.Text;
            string phone = textBox6.Text;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление");
                return;
            }

            if (checkClient(Convert.ToInt32(textBox1.Text))) { }
            else
            {
                return;
            }

            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                string query = "INSERT INTO Клиент (КодКлиента, Фамилия, Имя, Отчество, ПаспортныеДанные, Телефон) VALUES (" + kod + ",'" + surname + "', '" + name + "', '" + patronymic + "', '" + passport + "', '" + phone + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
            }
        }
        private bool checkClient(int kod)
        {
            try
            {
                string query = "SELECT КодКлиента FROM Клиент WHERE КодКлиента = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = (int)reader["КодКлиента"];
                MessageBox.Show("Данное значение кода уже занято", "Уведомление");
                return false;
            }
            catch
            {
                return true;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }

        private void ClientCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
