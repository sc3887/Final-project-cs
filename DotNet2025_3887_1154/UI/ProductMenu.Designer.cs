namespace UI
{
    partial class ProductMenu
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button5 = new Button();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            label5 = new Label();
            label1 = new Label();
            tabPage2 = new TabPage();
            label2 = new Label();
            tabPage3 = new TabPage();
            button6 = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            tabPage4 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(612, 37);
            button1.Name = "button1";
            button1.Size = new Size(154, 83);
            button1.TabIndex = 0;
            button1.Text = "מוצרים";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(612, 139);
            button2.Name = "button2";
            button2.Size = new Size(154, 83);
            button2.TabIndex = 0;
            button2.Text = "מוצרים";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(612, 238);
            button3.Name = "button3";
            button3.Size = new Size(154, 83);
            button3.TabIndex = 0;
            button3.Text = "מוצרים";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(612, 337);
            button4.Name = "button4";
            button4.Size = new Size(154, 83);
            button4.TabIndex = 0;
            button4.Text = "מוצרים";
            button4.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(110, 56);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(478, 354);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(numericUpDown1);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(470, 321);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "הוספה";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // button5
            // 
            button5.Location = new Point(123, 240);
            button5.Name = "button5";
            button5.Size = new Size(94, 29);
            button5.TabIndex = 3;
            button5.Text = "שמור";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(184, 110);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(125, 27);
            numericUpDown1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(184, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(388, 117);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 0;
            label5.Text = "מחיר";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(353, 54);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "שם המוצר";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(470, 321);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "עדכון";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(252, 169);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 0;
            label2.Text = "label2";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button6);
            tabPage3.Controls.Add(textBox2);
            tabPage3.Controls.Add(label3);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(470, 321);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "מחיקה";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(312, 254);
            button6.Name = "button6";
            button6.Size = new Size(94, 29);
            button6.TabIndex = 2;
            button6.Text = "מחיקה";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(267, 167);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(256, 105);
            label3.Name = "label3";
            label3.Size = new Size(157, 20);
            label3.TabIndex = 0;
            label3.Text = "הקש קוד מוצר למחיקה";
            label3.Click += label3_Click;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(470, 321);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "תצוגה";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // ProductMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ProductMenu";
            Text = "ProductMenu";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button5;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private Label label5;
        private Button button6;
        private TextBox textBox2;
    }
}