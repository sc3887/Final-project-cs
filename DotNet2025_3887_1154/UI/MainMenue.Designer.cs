namespace UI
{
    partial class MainMenue
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(566, 120);
            button1.Name = "button1";
            button1.Size = new Size(184, 103);
            button1.TabIndex = 0;
            button1.Text = "מוצרים";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(336, 120);
            button2.Name = "button2";
            button2.Size = new Size(184, 103);
            button2.TabIndex = 0;
            button2.Text = "מבצעים";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(92, 120);
            button3.Name = "button3";
            button3.Size = new Size(184, 103);
            button3.TabIndex = 0;
            button3.Text = "לקוחות";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(92, 325);
            button4.Name = "button4";
            button4.Size = new Size(184, 76);
            button4.TabIndex = 0;
            button4.Text = "הזמנה חדשה";
            button4.UseVisualStyleBackColor = true;
            // 
            // MainMenue
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "MainMenue";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}
