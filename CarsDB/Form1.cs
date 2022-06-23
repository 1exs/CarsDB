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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Cars cars;
        private void button1_Click(object sender, EventArgs e)
        {
            cars = new Cars();
            cars.Show();
        }
        Action action;
        private void button2_Click(object sender, EventArgs e)
        {
            action = new Action();
            action.Show();
        }
        Contract contract;
        private void button3_Click(object sender, EventArgs e)
        {
            contract = new Contract();
            contract.Show();
        }
        Position position;
        private void button4_Click(object sender, EventArgs e)
        {
            position = new Position();
            position.Show();
        }
        Service service;
        private void button5_Click(object sender, EventArgs e)
        {
            service = new Service();
            service.Show();
        }
        Client client;
        private void button6_Click(object sender, EventArgs e)
        {
            client = new Client();
            client.Show();
        }
        Package package;
        private void button7_Click(object sender, EventArgs e)
        {
            package = new Package();
            package.Show();
        }
        Assembly assembly;
        private void button8_Click(object sender, EventArgs e)
        {
            assembly = new Assembly();
            assembly.Show();
        }
        Worker worker;
        private void button9_Click(object sender, EventArgs e)
        {
            worker = new Worker();
            worker.Show();
        }
        Branch branch;
        private void button10_Click(object sender, EventArgs e)
        {
            branch = new Branch();
            branch.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
