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
    public partial class Assembly : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public Assembly()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void местоСборкиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.местоСборкиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carsDataSet);

        }

        private void Assembly_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carsDataSet.МестоСборки". При необходимости она может быть перемещена или удалена.
            this.местоСборкиTableAdapter.Fill(this.carsDataSet.МестоСборки);

        }
        AssemblyCreate create;
        private void button5_Click(object sender, EventArgs e)
        {
            create = new AssemblyCreate();
            create.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.местоСборкиTableAdapter.Fill(this.carsDataSet.МестоСборки);
        }

        AssemblyChange change;
        private void button3_Click(object sender, EventArgs e)
        {
            int kod;
            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                try
                {
                    string query = "SELECT КодМеста FROM МестоСборки WHERE КодМеста = " + kod;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int count = (int)reader["КодМеста"];
                    change = new AssemblyChange(kod);
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
    }
}
