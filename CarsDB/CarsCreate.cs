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

    public partial class CarsCreate : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public CarsCreate()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod;
            string model = textBox2.Text;
            int price;
            string color = textBox4.Text;
            int luxury;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление");
                return;
            }

            if (checkAuto(Convert.ToInt32(textBox5.Text))) { }
            else
            {
                return;
            }
            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                price = Convert.ToInt32(textBox3.Text);
                luxury = Convert.ToInt32(textBox5.Text);
                string query = "INSERT INTO Автомобиль (Код_автомобиля, Модель, Цена, Цвет, КодКомплектации) VALUES (" + kod + ",'" + model + "', '" + price + "', '" + color + "', '" + luxury + "')";
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
                string query = "SELECT КодКомплектации FROM Комплектация WHERE КодКомплектации = " + kod;
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                int count = (int)reader["КодКомплектации"];
                return true;
            }
            catch
            {
                MessageBox.Show("Введенное значение комплектации не найдено", "Уведомление");
                return false;
            }
        }

        private void CarsCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
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
