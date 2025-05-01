namespace UI
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            listAllClientsDetails = new ListBox();
            tabControl1 = new TabControl();
            tabPageClientDetail = new TabPage();
            button_OK = new Button();
            listBoxClientDetails = new ListBox();
            numericUpDownClientId = new NumericUpDown();
            textBox1 = new TextBox();
            tabPageAllClientDetails = new TabPage();
            listBox1AllClients = new ListBox();
            buttonAllCliens = new Button();
            ClientNameFilter = new TextBox();
            label6 = new Label();
            tabPageAddClient = new TabPage();
            tabPageUpdateClient = new TabPage();
            updeteClient = new Button();
            clientPhone = new TextBox();
            clientAdress = new TextBox();
            clientName = new TextBox();
            clientID = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tabPageDeleteClient = new TabPage();
            buttonDeleteClient = new Button();
            DeleteClientId = new TextBox();
            label1 = new Label();
            bindingSource1 = new BindingSource(components);
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            addClientId = new TextBox();
            addClientName = new TextBox();
            addClientAdress = new TextBox();
            addClientPhone = new TextBox();
            buttonAdd = new Button();
            tabControl1.SuspendLayout();
            tabPageClientDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownClientId).BeginInit();
            tabPageAllClientDetails.SuspendLayout();
            tabPageAddClient.SuspendLayout();
            tabPageUpdateClient.SuspendLayout();
            tabPageDeleteClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // listAllClientsDetails
            // 
            listAllClientsDetails.FormattingEnabled = true;
            listAllClientsDetails.Location = new Point(524, 65);
            listAllClientsDetails.Name = "listAllClientsDetails";
            listAllClientsDetails.Size = new Size(252, 344);
            listAllClientsDetails.TabIndex = 0;
            listAllClientsDetails.SelectedIndexChanged += listAllClientsDetails_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageClientDetail);
            tabControl1.Controls.Add(tabPageAllClientDetails);
            tabControl1.Controls.Add(tabPageAddClient);
            tabControl1.Controls.Add(tabPageUpdateClient);
            tabControl1.Controls.Add(tabPageDeleteClient);
            tabControl1.Location = new Point(25, 65);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(482, 344);
            tabControl1.TabIndex = 1;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPageClientDetail
            // 
            tabPageClientDetail.Controls.Add(button_OK);
            tabPageClientDetail.Controls.Add(listBoxClientDetails);
            tabPageClientDetail.Controls.Add(numericUpDownClientId);
            tabPageClientDetail.Controls.Add(textBox1);
            tabPageClientDetail.Location = new Point(4, 29);
            tabPageClientDetail.Name = "tabPageClientDetail";
            tabPageClientDetail.Padding = new Padding(3);
            tabPageClientDetail.Size = new Size(474, 311);
            tabPageClientDetail.TabIndex = 0;
            tabPageClientDetail.Text = "פרטי לקוח";
            tabPageClientDetail.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            button_OK.Location = new Point(67, 46);
            button_OK.Name = "button_OK";
            button_OK.Size = new Size(94, 29);
            button_OK.TabIndex = 4;
            button_OK.Text = "אישור";
            button_OK.UseVisualStyleBackColor = true;
            button_OK.Click += button_OK_Click;
            // 
            // listBoxClientDetails
            // 
            listBoxClientDetails.FormattingEnabled = true;
            listBoxClientDetails.Location = new Point(247, 177);
            listBoxClientDetails.Name = "listBoxClientDetails";
            listBoxClientDetails.Size = new Size(150, 104);
            listBoxClientDetails.TabIndex = 3;
            listBoxClientDetails.SelectedIndexChanged += listBoxClientDetails_SelectedIndexChanged;
            // 
            // numericUpDownClientId
            // 
            numericUpDownClientId.Location = new Point(179, 46);
            numericUpDownClientId.Name = "numericUpDownClientId";
            numericUpDownClientId.Size = new Size(118, 27);
            numericUpDownClientId.TabIndex = 1;
            numericUpDownClientId.ValueChanged += numericUpDownClientId_ValueChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(317, 45);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            textBox1.Text = "הכנס מזהה לקוח";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // tabPageAllClientDetails
            // 
            tabPageAllClientDetails.Controls.Add(listBox1AllClients);
            tabPageAllClientDetails.Controls.Add(buttonAllCliens);
            tabPageAllClientDetails.Controls.Add(ClientNameFilter);
            tabPageAllClientDetails.Controls.Add(label6);
            tabPageAllClientDetails.Location = new Point(4, 29);
            tabPageAllClientDetails.Name = "tabPageAllClientDetails";
            tabPageAllClientDetails.Padding = new Padding(3);
            tabPageAllClientDetails.Size = new Size(474, 311);
            tabPageAllClientDetails.TabIndex = 1;
            tabPageAllClientDetails.Text = "פרטי כל הלקוחות";
            tabPageAllClientDetails.UseVisualStyleBackColor = true;
            // 
            // listBox1AllClients
            // 
            listBox1AllClients.FormattingEnabled = true;
            listBox1AllClients.Location = new Point(229, 177);
            listBox1AllClients.Name = "listBox1AllClients";
            listBox1AllClients.Size = new Size(150, 104);
            listBox1AllClients.TabIndex = 3;
            // 
            // buttonAllCliens
            // 
            buttonAllCliens.Location = new Point(60, 58);
            buttonAllCliens.Name = "buttonAllCliens";
            buttonAllCliens.Size = new Size(94, 29);
            buttonAllCliens.TabIndex = 2;
            buttonAllCliens.Text = "אישור";
            buttonAllCliens.UseVisualStyleBackColor = true;
            buttonAllCliens.Click += buttonAllCliens_Click;
            // 
            // ClientNameFilter
            // 
            ClientNameFilter.Location = new Point(189, 55);
            ClientNameFilter.Name = "ClientNameFilter";
            ClientNameFilter.Size = new Size(125, 27);
            ClientNameFilter.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(334, 58);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 0;
            label6.Text = "הכנס שם לסינון";
            // 
            // tabPageAddClient
            // 
            tabPageAddClient.Controls.Add(buttonAdd);
            tabPageAddClient.Controls.Add(addClientPhone);
            tabPageAddClient.Controls.Add(addClientAdress);
            tabPageAddClient.Controls.Add(addClientName);
            tabPageAddClient.Controls.Add(addClientId);
            tabPageAddClient.Controls.Add(label10);
            tabPageAddClient.Controls.Add(label9);
            tabPageAddClient.Controls.Add(label8);
            tabPageAddClient.Controls.Add(label7);
            tabPageAddClient.Location = new Point(4, 29);
            tabPageAddClient.Name = "tabPageAddClient";
            tabPageAddClient.Size = new Size(474, 311);
            tabPageAddClient.TabIndex = 2;
            tabPageAddClient.Text = "הוספת לקוח";
            tabPageAddClient.UseVisualStyleBackColor = true;
            // 
            // tabPageUpdateClient
            // 
            tabPageUpdateClient.Controls.Add(updeteClient);
            tabPageUpdateClient.Controls.Add(clientPhone);
            tabPageUpdateClient.Controls.Add(clientAdress);
            tabPageUpdateClient.Controls.Add(clientName);
            tabPageUpdateClient.Controls.Add(clientID);
            tabPageUpdateClient.Controls.Add(label5);
            tabPageUpdateClient.Controls.Add(label4);
            tabPageUpdateClient.Controls.Add(label3);
            tabPageUpdateClient.Controls.Add(label2);
            tabPageUpdateClient.Location = new Point(4, 29);
            tabPageUpdateClient.Name = "tabPageUpdateClient";
            tabPageUpdateClient.Size = new Size(474, 311);
            tabPageUpdateClient.TabIndex = 3;
            tabPageUpdateClient.Text = "עדכון לקוח";
            tabPageUpdateClient.UseVisualStyleBackColor = true;
            // 
            // updeteClient
            // 
            updeteClient.Location = new Point(222, 270);
            updeteClient.Name = "updeteClient";
            updeteClient.Size = new Size(94, 29);
            updeteClient.TabIndex = 5;
            updeteClient.Text = "עדכון";
            updeteClient.UseVisualStyleBackColor = true;
            updeteClient.Click += updeteClient_Click;
            // 
            // clientPhone
            // 
            clientPhone.Location = new Point(118, 237);
            clientPhone.Name = "clientPhone";
            clientPhone.Size = new Size(125, 27);
            clientPhone.TabIndex = 4;
            // 
            // clientAdress
            // 
            clientAdress.Location = new Point(118, 170);
            clientAdress.Name = "clientAdress";
            clientAdress.Size = new Size(125, 27);
            clientAdress.TabIndex = 3;
            // 
            // clientName
            // 
            clientName.Location = new Point(118, 115);
            clientName.Name = "clientName";
            clientName.Size = new Size(125, 27);
            clientName.TabIndex = 2;
            // 
            // clientID
            // 
            clientID.Location = new Point(118, 60);
            clientID.Name = "clientID";
            clientID.Size = new Size(125, 27);
            clientID.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(297, 240);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 0;
            label5.Text = "טלפון:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(289, 177);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 0;
            label4.Text = "כתובת:";
            label4.Click += label4_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(297, 115);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 0;
            label3.Text = "שם:";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(310, 60);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 0;
            label2.Text = "הכנס מזהה לעדכון";
            // 
            // tabPageDeleteClient
            // 
            tabPageDeleteClient.Controls.Add(buttonDeleteClient);
            tabPageDeleteClient.Controls.Add(DeleteClientId);
            tabPageDeleteClient.Controls.Add(label1);
            tabPageDeleteClient.Location = new Point(4, 29);
            tabPageDeleteClient.Name = "tabPageDeleteClient";
            tabPageDeleteClient.Size = new Size(474, 311);
            tabPageDeleteClient.TabIndex = 4;
            tabPageDeleteClient.Text = "מחיקת לקוח";
            tabPageDeleteClient.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteClient
            // 
            buttonDeleteClient.Location = new Point(36, 82);
            buttonDeleteClient.Name = "buttonDeleteClient";
            buttonDeleteClient.Size = new Size(94, 29);
            buttonDeleteClient.TabIndex = 2;
            buttonDeleteClient.Text = "למחיקה";
            buttonDeleteClient.UseVisualStyleBackColor = true;
            buttonDeleteClient.Click += buttonDeleteClient_Click;
            // 
            // DeleteClientId
            // 
            DeleteClientId.Location = new Point(150, 82);
            DeleteClientId.Name = "DeleteClientId";
            DeleteClientId.Size = new Size(125, 27);
            DeleteClientId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 82);
            label1.Name = "label1";
            label1.Size = new Size(138, 20);
            label1.TabIndex = 0;
            label1.Text = "הכנס מזהה למחיקה";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(345, 49);
            label7.Name = "label7";
            label7.Size = new Size(88, 20);
            label7.TabIndex = 0;
            label7.Text = "מספר מזהה:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(345, 97);
            label8.Name = "label8";
            label8.Size = new Size(34, 20);
            label8.TabIndex = 0;
            label8.Text = "שם:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(345, 151);
            label9.Name = "label9";
            label9.Size = new Size(55, 20);
            label9.TabIndex = 0;
            label9.Text = "כתובת:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(345, 196);
            label10.Name = "label10";
            label10.Size = new Size(47, 20);
            label10.TabIndex = 1;
            label10.Text = "טלפון:";
            // 
            // addClientId
            // 
            addClientId.Location = new Point(185, 49);
            addClientId.Name = "addClientId";
            addClientId.Size = new Size(125, 27);
            addClientId.TabIndex = 2;
            // 
            // addClientName
            // 
            addClientName.Location = new Point(185, 97);
            addClientName.Name = "addClientName";
            addClientName.Size = new Size(125, 27);
            addClientName.TabIndex = 2;
            // 
            // addClientAdress
            // 
            addClientAdress.Location = new Point(185, 151);
            addClientAdress.Name = "addClientAdress";
            addClientAdress.Size = new Size(125, 27);
            addClientAdress.TabIndex = 2;
            // 
            // addClientPhone
            // 
            addClientPhone.Location = new Point(185, 196);
            addClientPhone.Name = "addClientPhone";
            addClientPhone.Size = new Size(125, 27);
            addClientPhone.TabIndex = 2;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(242, 268);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 29);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "הוספה";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(listAllClientsDetails);
            Name = "ClientForm";
            Text = "ClientForm";
            tabControl1.ResumeLayout(false);
            tabPageClientDetail.ResumeLayout(false);
            tabPageClientDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownClientId).EndInit();
            tabPageAllClientDetails.ResumeLayout(false);
            tabPageAllClientDetails.PerformLayout();
            tabPageAddClient.ResumeLayout(false);
            tabPageAddClient.PerformLayout();
            tabPageUpdateClient.ResumeLayout(false);
            tabPageUpdateClient.PerformLayout();
            tabPageDeleteClient.ResumeLayout(false);
            tabPageDeleteClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listAllClientsDetails;
        private TabControl tabControl1;
        private TabPage tabPageClientDetail;
        private TabPage tabPageAllClientDetails;
        private TabPage tabPageAddClient;
        private TabPage tabPageUpdateClient;
        private TabPage tabPageDeleteClient;
        private BindingSource bindingSource1;
        private ListBox listBoxClientDetails;
        private NumericUpDown numericUpDownClientId;
        private TextBox textBox1;
        private Button button_OK;
        private Button buttonDeleteClient;
        private TextBox DeleteClientId;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox clientAdress;
        private TextBox clientName;
        private TextBox clientID;
        private TextBox clientPhone;
        private Button updeteClient;
        private Label label6;
        private TextBox ClientNameFilter;
        private ListBox listBox1AllClients;
        private Button buttonAllCliens;
        private Label label7;
        private Button buttonAdd;
        private TextBox addClientPhone;
        private TextBox addClientAdress;
        private TextBox addClientName;
        private TextBox addClientId;
        private Label label10;
        private Label label9;
        private Label label8;
    }
}