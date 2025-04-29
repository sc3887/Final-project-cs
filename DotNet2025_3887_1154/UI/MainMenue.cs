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
    }
}
