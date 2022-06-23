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
    public partial class ActionCreate : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public ActionCreate()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int kod;
            string name = textBox2.Text;
            string inform = textBox3.Text;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Не все поля заполнены", "Уведомление");
                return;
            }

            try
            {
                    kod = Convert.ToInt32(textBox1.Text);
                    string query = "INSERT INTO Акции (КодАкции, Название, Описание) VALUES (" + kod + ",'" + name + "', '" + inform + "')";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    this.Close();
            }
            catch
            {
                MessageBox.Show("Некорректные данные", "Ошибка");
            }
        }

        private void ActionCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
