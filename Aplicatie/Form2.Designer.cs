namespace LoginForm
{
    partial class Form2
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
            dataGridView2 = new DataGridView();
            button1 = new Button();
            textBox1 = new TextBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 44);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 47;
            dataGridView2.Size = new Size(1199, 496);
            dataGridView2.TabIndex = 1;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // button1
            // 
            button1.Font = new Font("Yu Gothic", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(589, 161);
            button1.Name = "button1";
            button1.Size = new Size(102, 26);
            button1.TabIndex = 2;
            button1.Text = "Categorii";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(589, 118);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(49, 26);
            textBox1.TabIndex = 3;
            textBox1.Text = "MENU";
            // 
            // button2
            // 
            button2.Font = new Font("Yu Gothic", 9.818182F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(589, 204);
            button2.Name = "button2";
            button2.Size = new Size(102, 26);
            button2.TabIndex = 4;
            button2.Text = "Utilizatori";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1242, 552);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Name = "Form2";
            Text = "Form2";
            FormClosing += Menuform_FormClosing;
            FormClosed += Form2_FormClosed;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView2;
        private Button button1;
        private TextBox textBox1;
        private Button button2;
    }
}