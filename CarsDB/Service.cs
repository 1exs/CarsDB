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
    public partial class Service : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public Service()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void допУслугиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.допУслугиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carsDataSet);

        }

        private void Service_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carsDataSet.ДопУслуги". При необходимости она может быть перемещена или удалена.
            this.допУслугиTableAdapter.Fill(this.carsDataSet.ДопУслуги);

        }
        ServiceCreate create;
        private void button5_Click(object sender, EventArgs e)
        {
            create = new ServiceCreate();
            create.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.допУслугиTableAdapter.Fill(this.carsDataSet.ДопУслуги);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                e.Handled = !char.IsNumber(e.KeyChar);
            }
        }
        ServiceChange change;
        private void button3_Click(object sender, EventArgs e)
        {
            int kod;
            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                try
                {
                    string query = "SELECT КодУслуги FROM ДопУслуги WHERE КодУслуги = " + kod;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int count = (int)reader["КодУслуги"];
                    change = new ServiceChange(kod);
                    change.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Введённая услуга не найдена", "Уведомление");
                }
            }
            catch
            {
                MessageBox.Show("Введите число", "Уведомление");
            }
        }
    }
}
