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
    public partial class CarSearch : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public CarSearch()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();
                string text1 = textBox1.Text;
                string text2 = textBox2.Text;
                string query = "SELECT Модель, Цена, Цвет, КодКомплектации, КодМестаСборки, КодФилиала, КодДоговора FROM Автомобиль WHERE Модель LIKE '%" + text1 + "%' AND Цвет LIKE '%" + text2 + "%'";
                OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
                DataTable dt = new DataTable();
                command.Fill(dt);
                dataGridView1.DataSource = dt;
                myConnection.Close();
            }
            else
            {
                if (checkBox1.Checked == true)
                {
                    myConnection = new OleDbConnection(connectString);
                    myConnection.Open();
                    string text = textBox1.Text;
                    string query = "SELECT Модель, Цена, Цвет, КодКомплектации, КодМестаСборки, КодФилиала, КодДоговора FROM Автомобиль WHERE Модель LIKE '%" + text + "%'";
                    OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
                    DataTable dt = new DataTable();
                    command.Fill(dt);
                    dataGridView1.DataSource = dt;
                    myConnection.Close();
                }
                else
                {
                    if (checkBox2.Checked == true)
                    {
                        myConnection = new OleDbConnection(connectString);
                        myConnection.Open();
                        string text = textBox2.Text;
                        string query = "SELECT Модель, Цена, Цвет, КодКомплектации, КодМестаСборки, КодФилиала, КодДоговора FROM Автомобиль WHERE Цвет LIKE '%" + text + "%'";
                        OleDbDataAdapter command = new OleDbDataAdapter(query, myConnection);
                        DataTable dt = new DataTable();
                        command.Fill(dt);
                        dataGridView1.DataSource = dt;
                        myConnection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Для поиска необходимо включить галочку", "Уведомление");
                    }
                }
            }
        }

        private void CarSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
