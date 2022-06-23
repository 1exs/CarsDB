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
    public partial class WorkerCreate : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public WorkerCreate()
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
            int position;
            string phone = textBox6.Text;
            int branch;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление");
                return;
            }

            if (checkWorker(Convert.ToInt32(textBox1.Text))) { }
            else
            {
                return;
            }

            if (checkPosition(Convert.ToInt32(textBox5.Text))) { }
            else            
            {
                return;
            }

            if (checkBranch(Convert.ToInt32(textBox7.Text))) { }
            else
            {
                return;
            }

            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                position = Convert.ToInt32(textBox5.Text);
                branch = Convert.ToInt32(textBox7.Text);
                string query = "INSERT INTO Сотрудник (КодСотрудника, Фамилия, Имя, Отчетсво, КодДолжности, Телефон, КодФилиала) VALUES (" + kod + ",'" + surname + "', '" + name + "', '" + patronymic + "', '" + position + "', '" + phone + "', '" + branch + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
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
                MessageBox.Show("Данный код сотрудника уже занят", "Уведомление");
                return false;
            }
            catch
            {
                return true;
            }
        }
        private bool checkPosition(int kod)
        {
            try
            {
                string query = "SELECT КодДолжности FROM Должности WHERE КодДолжности = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = (int)reader["КодДолжности"];
                return true;
            }
            catch
            {
                MessageBox.Show("Введенное значение должности не найдено", "Уведомление");
                return false;
            }
        }
        private bool checkBranch(int kod)
        {
            try
            {
                string query = "SELECT КодФилиала FROM Филиал WHERE КодФилиала = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = (int)reader["КодФилиала"];
                return true;
            }
            catch
            {
                MessageBox.Show("Введенное значение филиала не найдено", "Уведомление");
                return false;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }
    }
}
