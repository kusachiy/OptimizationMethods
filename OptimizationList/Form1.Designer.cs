namespace OptimizationList
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textA = new System.Windows.Forms.TextBox();
            this.textB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textEPS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusbar = new System.Windows.Forms.TextBox();
            this.textXmin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textYmin = new System.Windows.Forms.TextBox();
            this.timestamp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textA
            // 
            this.textA.Location = new System.Drawing.Point(186, 25);
            this.textA.Name = "textA";
            this.textA.Size = new System.Drawing.Size(75, 20);
            this.textA.TabIndex = 0;
            // 
            // textB
            // 
            this.textB.Location = new System.Drawing.Point(284, 25);
            this.textB.Name = "textB";
            this.textB.Size = new System.Drawing.Size(75, 20);
            this.textB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Укажите интервал поиска:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выберите метод поиска:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 40);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textEPS
            // 
            this.textEPS.Location = new System.Drawing.Point(425, 25);
            this.textEPS.Name = "textEPS";
            this.textEPS.Size = new System.Drawing.Size(89, 20);
            this.textEPS.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "(EPS/N):";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 28);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 69);
            this.listBox1.TabIndex = 8;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // statusbar
            // 
            this.statusbar.Location = new System.Drawing.Point(12, 223);
            this.statusbar.Name = "statusbar";
            this.statusbar.ReadOnly = true;
            this.statusbar.Size = new System.Drawing.Size(502, 20);
            this.statusbar.TabIndex = 9;
            // 
            // textXmin
            // 
            this.textXmin.Location = new System.Drawing.Point(225, 103);
            this.textXmin.Name = "textXmin";
            this.textXmin.Size = new System.Drawing.Size(134, 20);
            this.textXmin.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(183, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Xmin =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ymin =";
            // 
            // textYmin
            // 
            this.textYmin.Location = new System.Drawing.Point(225, 126);
            this.textYmin.Name = "textYmin";
            this.textYmin.Size = new System.Drawing.Size(134, 20);
            this.textYmin.TabIndex = 12;
            // 
            // timestamp
            // 
            this.timestamp.Location = new System.Drawing.Point(425, 62);
            this.timestamp.Name = "timestamp";
            this.timestamp.Size = new System.Drawing.Size(89, 20);
            this.timestamp.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Время :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 255);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timestamp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textYmin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textXmin);
            this.Controls.Add(this.statusbar);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textEPS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textB);
            this.Controls.Add(this.textA);
            this.Name = "Form1";
            this.Text = "Start";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textA;
        private System.Windows.Forms.TextBox textB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textEPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox statusbar;
        private System.Windows.Forms.TextBox textXmin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textYmin;
        private System.Windows.Forms.TextBox timestamp;
        private System.Windows.Forms.Label label6;
    }
}

