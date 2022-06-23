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
    public partial class ContractsChange : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        int kod;
        public ContractsChange(int text)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            kod = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Договор SET [Тип оплаты] = '" + textBox1.Text + "' WHERE Код_договора = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Договор SET ДатаЗаключения = '" + Convert.ToDateTime(textBox2.Text) + "' WHERE Код_договора = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Некорректное значение даты", "Ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Договор SET Доставка = '" + textBox4.Text + "' WHERE Код_договора = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Договор SET КодАвтомобиля = '" + Convert.ToInt32(textBox5.Text) + "' WHERE Код_договора = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Договор SET КодКлиента = '" + Convert.ToInt32(textBox6.Text) + "' WHERE Код_договора = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Договор SET КодСотрудника = '" + Convert.ToInt32(textBox7.Text) + "' WHERE Код_договора = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Договор SET КодДопУслуги = '" + Convert.ToInt32(textBox8.Text) + "' WHERE Код_договора = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
    }
}
