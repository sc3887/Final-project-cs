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

    public partial class ProductMenu : Form
    {
        private static IBl _bl = BlApi.Factory.Get();

        public ProductMenu()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.productName = textBox1.Text;
            p.productPrice = (int)numericUpDown1.Value;
            _bl.Product.Create(p);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            _bl.Product.Delete(int.Parse(textBox1.Text));
        }
    }
}
