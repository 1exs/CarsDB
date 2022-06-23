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
    public partial class Action : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        public Action()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void акцииBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.акцииBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.carsDataSet);

        }

        private void Action_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carsDataSet.Акции". При необходимости она может быть перемещена или удалена.
            this.акцииTableAdapter.Fill(this.carsDataSet.Акции);

        }
        ActionCreate create;
        private void button1_Click(object sender, EventArgs e)
        {
            create = new ActionCreate();
            create.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.акцииTableAdapter.Fill(this.carsDataSet.Акции);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kod;

            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите число", "Уведомление");
            }
            else
            {
                try
                {
                    kod = Convert.ToInt32(textBox1.Text);
                    try
                    {
                        string query = "SELECT КодАкции FROM Акции WHERE КодАкции = " + kod;
                        OleDbCommand command = new OleDbCommand(query, myConnection);
                        OleDbDataReader reader = command.ExecuteReader();
                        reader.Read();
                        int count = (int)reader["КодАкции"];
                    }
                    catch
                    {
                        MessageBox.Show("Введёное значение не найдено", "Уведомление");
                        return;
                    }


                    DialogResult result = MessageBox.Show("Удалить акцию?", "Сообщение", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string query = "DELETE FROM Акции WHERE [КодАкции] = " + kod;
                        OleDbCommand command = new OleDbCommand(query, myConnection);
                        command.ExecuteNonQuery();
                    }

                }
                catch
                {
                    MessageBox.Show("Введите число", "Уведомление");
                }
            }
        }
        ActionChange change;
        private void button4_Click(object sender, EventArgs e)
        {
            int kod;
            try
            {
                kod = Convert.ToInt32(textBox1.Text);
                try
                {
                    string query = "SELECT КодАкции FROM Акции WHERE КодАкции = " + kod;
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    reader.Read();
                    int count = (int)reader["КодАкции"];
                    change = new ActionChange(kod);
                    change.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Введёное значение не найдено", "Уведомление");
                }
            }
            catch
            {
                MessageBox.Show("Введите число","Уведомление");
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
