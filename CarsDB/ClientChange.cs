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
    public partial class ClientChange : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        int kod;
        public ClientChange(int text)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            kod = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Клиент SET Фамилия = '" + textBox1.Text + "' WHERE КодКлиента = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Клиент SET Имя = '" + textBox2.Text + "' WHERE КодКлиента = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Клиент SET Отчество = '" + textBox4.Text + "' WHERE КодКлиента = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Клиент SET ПаспортныеДанные = '" + textBox5.Text + "' WHERE КодКлиента = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Клиент SET Телефон = '" + textBox6.Text + "' WHERE КодКлиента = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Клиент SET КодДоговора = '" + Convert.ToInt32(textBox7.Text) + "' WHERE КодКлиента = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }
    }
}
