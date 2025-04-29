namespace UI
{
    partial class OrderForm
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
            listBox1 = new ListBox();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(36, 29);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(287, 404);
            listBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(669, 63);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 1;
            label1.Text = "קוד מוצר";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(505, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Location = new Point(529, 166);
            button1.Name = "button1";
            button1.Size = new Size(218, 29);
            button1.TabIndex = 3;
            button1.Text = "בחירה מתוך הרשימה";
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(669, 103);
            label2.Name = "label2";
            label2.Size = new Size(95, 20);
            label2.TabIndex = 4;
            label2.Text = "כמות להזמנה";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(505, 113);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(125, 27);
            numericUpDown1.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(529, 229);
            button2.Name = "button2";
            button2.Size = new Size(218, 29);
            button2.TabIndex = 3;
            button2.Text = "הוסף להזמנה";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numericUpDown1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "OrderForm";
            Text = "OrderForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button button2;
    }
}