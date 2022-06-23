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
    public partial class WorkerChange : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        int kod;
        public WorkerChange(int text)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            kod = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Сотрудник SET Фамилия = '" + textBox1.Text + "' WHERE [КодСотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Сотрудник SET Имя = '" + textBox2.Text + "' WHERE [КодСотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Сотрудник SET Отчетсво = '" + textBox3.Text + "' WHERE [КодСотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Сотрудник SET КодДолжности = '" + Convert.ToInt32(textBox4.Text) + "' WHERE [КодСотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Сотрудник SET Телефон = '" + textBox5.Text + "' WHERE [КодСотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Сотрудник SET КодФилиала = '" + Convert.ToInt32(textBox6.Text) + "' WHERE [КодСотрудника] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }
    }
}
