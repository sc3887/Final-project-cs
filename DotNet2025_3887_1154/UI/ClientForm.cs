using BlApi;
using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class ClientForm : Form
    {
        static readonly IBl s_bl = Factory.Get();
        public ClientForm()
        {
            InitializeComponent();
            listAllClientsDetails.DataSource = s_bl.Client.ReadAll().SelectMany(c => c.ToStringProperty().Split("\n")).ToList();
            listBox1AllClients.DataSource = s_bl.Client.ReadAll().SelectMany(c => c.ToStringProperty().Split("\n")).ToList();

        }

        private void listAllClientsDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxClientDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownClientId_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            int ClientId = (int)numericUpDownClientId.Value;
            Client? client = s_bl.Client.Read(ClientId);
            if (client == null)
            {
                MessageBox.Show("לא נמצא לקוח עם מזהה זה");
                return;
            }
            string clientDetails = client.ToStringProperty();
            var lines = clientDetails.Split('\n'); // פיצול לשורות

            listBoxClientDetails.DataSource = lines.ToList(); // הצגת השורות ברשימה
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            try
            {
                int clientId;
                int.TryParse(DeleteClientId.Text, out clientId);
                s_bl.Client.Delete(clientId);
                listAllClientsDetails.DataSource = s_bl.Client.ReadAll().SelectMany(c => c.ToStringProperty().Split("\n")).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void updeteClient_Click(object sender, EventArgs e)
        {
            try
            {
                int clientId;
                int.TryParse(clientID.Text, out clientId);
                BO.Client client = s_bl.Client.Read(clientId);
                client.clientName = clientName.Text != null ? clientName.Text : client.clientName;
                client.clientAddress = clientAdress.Text != null ? clientAdress.Text : client.clientAddress;
                client.clientPhone = clientPhone.Text != null ? clientPhone.Text : client.clientPhone;
                s_bl.Client.Update(client);
                listAllClientsDetails.DataSource = s_bl.Client.ReadAll().SelectMany(c => c.ToStringProperty().Split("\n")).ToList();
                clientID.Text = "";
                clientName.Text = "";
                clientAdress.Text = "";
                clientPhone.Text = "";
                MessageBox.Show("הלקוח עודכן בהצלחה");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonAllCliens_Click(object sender, EventArgs e)
        {
            string name = ClientNameFilter.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("לא הוזן טקסט בתיבת הטקסט");
                listBox1AllClients.DataSource = s_bl.Client.ReadAll().SelectMany(c => c.ToStringProperty().Split("\n")).ToList();
                return;
            }
            var filteredClients = s_bl.Client
        .ReadAll(c => string.Equals(c?.clientName, name, StringComparison.OrdinalIgnoreCase))
        .SelectMany(c => c!.ToStringProperty().Split("\n"))
        .ToList();
            listBox1AllClients.DataSource = filteredClients;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(addClientId.Text) || string.IsNullOrEmpty(addClientName.Text) || string.IsNullOrEmpty(addClientAdress.Text) || string.IsNullOrEmpty(addClientPhone.Text))
                {
                    MessageBox.Show("כל השדות חובה!");
                    addClientId.Text = "";
                    addClientName.Text = "";
                    addClientAdress.Text = "";
                    addClientPhone.Text = "";
                    return;
                }

                else
                {
                    Client client = new Client
                    {
                        clientId = int.Parse(addClientId.Text),
                        clientName = addClientName.Text,
                        clientAddress = addClientAdress.Text,
                        clientPhone = addClientPhone.Text
                    };
                    s_bl.Client.Create(client);
                    listAllClientsDetails.DataSource = s_bl.Client.ReadAll().SelectMany(c => c.ToStringProperty().Split("\n")).ToList();
                    addClientId.Text = "";
                    addClientName.Text = "";
                    addClientAdress.Text = "";
                    addClientPhone.Text = "";
                    MessageBox.Show("הלקוח נוסף בהצלחה");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
