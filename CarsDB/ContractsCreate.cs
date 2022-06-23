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
    public partial class ContractsCreate : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public ContractsCreate()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod;
            string check = textBox2.Text;
            string time = textBox3.Text;
            string delivery = textBox4.Text;
            int auto;
            int client;
            int worker;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление");
                return;
            }

            if (checkAuto(Convert.ToInt32(textBox5.Text))) { }
            else
            {
                return;
            }

            if (checkClient(Convert.ToInt32(textBox7.Text))) { }
            else
            {
                return;
            }

            if (checkWorker(Convert.ToInt32(textBox6.Text))) { }
            else
            {
                return;
            }

            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                auto = Convert.ToInt32(textBox5.Text);
                client = Convert.ToInt32(textBox7.Text);
                worker = Convert.ToInt32(textBox6.Text);
                string query = "INSERT INTO Договор (Код_договора, [Тип оплаты], ДатаЗаключения, Доставка, КодАвтомобиля, КодКлиента, КодСотрудника) VALUES (" + kod + ",'" + check + "', '" + Convert.ToDateTime(time) + "', '" + delivery + "', '" + auto + "', '" + client + "', '" + worker + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
            }
        }

        private bool checkAuto(int kod)
        {
            try
            {
                string query = "SELECT Код_Автомобиля FROM Автомобиль WHERE Код_Автомобиля = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = (int)reader["Код_Автомобиля"];
                return true;
            }
            catch
            {
                MessageBox.Show("Введенное значение автомобиля не найдено", "Уведомление");
                return false;
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
                return true;
            }
            catch
            {
                MessageBox.Show("Введенное значение клиента не найдено", "Уведомление");
                return false;
            }
        }
        private bool checkWorker(int kod)
        {
            try
            {
                string query = "SELECT КодСотрудника FROM Сотрудник WHERE КодСотрудника = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = (int)reader["КодСотрудника"];
                return true;
            }
            catch
            {
                MessageBox.Show("Введенное значение сотрудника не найдено", "Уведомление");
                return false;
            }
        }
        private void ContractsCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }
    }
}
