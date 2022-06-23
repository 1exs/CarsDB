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
    public partial class Cars : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public Cars()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void автомобильBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.автомобильBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carsDataSet);

        }

        private void Cars_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carsDataSet.Автомобиль". При необходимости она может быть перемещена или удалена.
            this.автомобильTableAdapter.Fill(this.carsDataSet.Автомобиль);

        }
        CarsReport report;
        private void button1_Click(object sender, EventArgs e)
        {
            report = new CarsReport();
            report.ShowDialog();
        }
        CarsCreate create;
        private void button5_Click(object sender, EventArgs e)
        {
            create = new CarsCreate();
            create.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.автомобильTableAdapter.Fill(this.carsDataSet.Автомобиль);
        }
        CarSearch search;
        private void button4_Click(object sender, EventArgs e)
        {
            search = new CarSearch();
            search.ShowDialog();
        }
        CarsChange updateCar;
        private void button3_Click(object sender, EventArgs e)
        {
            int kod;
            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                try
                {
                    string query = "SELECT Код_Автомобиля FROM Автомобиль WHERE Код_Автомобиля = " + kod;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int count = (int)reader["Код_Автомобиля"];
                    updateCar = new CarsChange(kod);
                    updateCar.Owner = this;
                    updateCar.ShowDialog();
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

        private void Cars_FormClosing(object sender, FormClosingEventArgs e)
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
