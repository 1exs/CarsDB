using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarsDB
{
    public partial class CarsReport : Form
    {
        public CarsReport()
        {
            InitializeComponent();
        }

        private void CarsReport_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "CarsDataSet.Автомобиль". При необходимости она может быть перемещена или удалена.
            this.АвтомобильTableAdapter.Fill(this.CarsDataSet.Автомобиль);

            this.reportViewer1.RefreshReport();
        }
    }
}
