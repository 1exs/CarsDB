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
    public partial class Client : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public Client()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void клиентBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.клиентBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carsDataSet);

        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carsDataSet.Клиент". При необходимости она может быть перемещена или удалена.
            this.клиентTableAdapter.Fill(this.carsDataSet.Клиент);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.клиентTableAdapter.Fill(this.carsDataSet.Клиент);
        }
        ClientCreate Create;
        private void button5_Click(object sender, EventArgs e)
        {
            Create = new ClientCreate();
            Create.Show();
        }
        ClientChange change;
        private void button3_Click(object sender, EventArgs e)
        {
            int kod;
            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                try
                {
                    string query = "SELECT КодКлиента FROM Клиент WHERE КодКлиента = " + kod;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int count = (int)reader["КодКлиента"];
                    change = new ClientChange(kod);
                    change.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Введёное значение не найдено", "Уведомление");
                }
            }
            catch
            {
                MessageBox.Show("Введите число", "Уведомление");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }
        ClientSearch search;
        private void button4_Click(object sender, EventArgs e)
        {
            search = new ClientSearch();
            search.ShowDialog();
        }
        ClientReport report;
        private void button1_Click(object sender, EventArgs e)
        {
            report = new ClientReport();
            report.ShowDialog();
        }
    }
}
