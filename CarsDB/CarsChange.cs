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
    public partial class CarsChange : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        int kod;
        public CarsChange(int key)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            kod = key;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Автомобиль SET Модель = '" + textBox1.Text + "' WHERE [Код_автомобиля] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = Convert.ToInt32(textBox2.Text);
                string query = "UPDATE Автомобиль SET Цена = '" + flag + "' WHERE [Код_автомобиля] = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Автомобиль SET Цвет = '" + textBox3.Text + "' WHERE [Код_автомобиля] = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = Convert.ToInt32(textBox4.Text);
                string query = "UPDATE Автомобиль SET КодКомплектации = '" + flag + "' WHERE [Код_автомобиля] = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = Convert.ToInt32(textBox5.Text);
                string query = "UPDATE Автомобиль SET КодМестаСборки = '" + flag + "' WHERE [Код_автомобиля] = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = Convert.ToInt32(textBox6.Text);
                string query = "UPDATE Автомобиль SET КодФилиала = '" + flag + "' WHERE [Код_автомобиля] = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = Convert.ToInt32(textBox7.Text);
                string query = "UPDATE Автомобиль SET КодДоговора = '" + flag + "' WHERE [Код_автомобиля] = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
            }
        }

        private void CarsChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
