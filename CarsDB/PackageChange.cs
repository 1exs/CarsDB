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
    public partial class PackageChange : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = Cars.accdb";
        private OleDbConnection myConnection;
        int kod;
        public PackageChange(int key)
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            kod = key;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Комплектация SET Комплектация = '" + textBox1.Text + "' WHERE КодКомплектации = " + kod;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            command.ExecuteNonQuery();
        }
    }
}
