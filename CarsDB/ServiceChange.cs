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
    public partial class ServiceChange : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        int kod;
        public ServiceChange(int text)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            kod = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE ДопУслуги SET НазваниеУслуги = '" + textBox1.Text + "' WHERE КодУслуги = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE ДопУслуги SET НазваниеКомпании = '" + textBox2.Text + "' WHERE КодУслуги = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "UPDATE ДопУслуги SET Описание = '" + textBox4.Text + "' WHERE КодУслуги = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }

        private void ServiceChange_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }
    }
}
