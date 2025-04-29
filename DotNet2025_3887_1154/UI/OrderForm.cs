using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlApi;
using BO;

namespace UI
{
    public partial class OrderForm : Form
    {
        private static IBl _bl = BlApi.Factory.Get();
        Order Order;
        Client client;

        public OrderForm()
        {
            InitializeComponent();
            Order = new Order(_bl.Client.isExist(client));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
