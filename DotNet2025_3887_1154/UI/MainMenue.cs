
namespace UI
{
    public partial class MainMenue : Form
    {
        public MainMenue()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductMenu form = new ProductMenu();
            form.ShowDialog();
        }

        private void MainMenue_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClientForm form = new ClientForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaleForm form = new SaleForm();
            form.ShowDialog();
        }
    }
}
