namespace Elective
{
    partial class Cashier_Interface
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cashier_Interface));
            panel1 = new Panel();
            timeLbl = new Label();
            dateLbl = new Label();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            button1 = new Button();
            textBox9 = new TextBox();
            label10 = new Label();
            cash_renderedtxtbox = new TextBox();
            label30 = new Label();
            changetxtbox = new TextBox();
            button21 = new Button();
            label31 = new Label();
            button2 = new Button();
            button19 = new Button();
            button20 = new Button();
            button18 = new Button();
            button17 = new Button();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            button11 = new Button();
            button10 = new Button();
            button9 = new Button();
            button6 = new Button();
            button16 = new Button();
            button7 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSeaGreen;
            panel1.Controls.Add(timeLbl);
            panel1.Controls.Add(dateLbl);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox9);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(cash_renderedtxtbox);
            panel1.Controls.Add(label30);
            panel1.Controls.Add(changetxtbox);
            panel1.Controls.Add(button21);
            panel1.Controls.Add(label31);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button19);
            panel1.Controls.Add(button20);
            panel1.Controls.Add(button18);
            panel1.Controls.Add(button17);
            panel1.Controls.Add(button14);
            panel1.Controls.Add(button13);
            panel1.Controls.Add(button12);
            panel1.Controls.Add(button11);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(button9);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button16);
            panel1.Controls.Add(button7);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1904, 1041);
            panel1.TabIndex = 0;
            // 
            // timeLbl
            // 
            timeLbl.AutoSize = true;
            timeLbl.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timeLbl.Location = new Point(69, 175);
            timeLbl.Margin = new Padding(4, 0, 4, 0);
            timeLbl.Name = "timeLbl";
            timeLbl.Size = new Size(73, 32);
            timeLbl.TabIndex = 207;
            timeLbl.Text = "Time";
            // 
            // dateLbl
            // 
            dateLbl.AutoSize = true;
            dateLbl.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dateLbl.Location = new Point(69, 129);
            dateLbl.Margin = new Padding(4, 0, 4, 0);
            dateLbl.Name = "dateLbl";
            dateLbl.Size = new Size(76, 32);
            dateLbl.TabIndex = 206;
            dateLbl.Text = "Date";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.DarkSlateGray;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(745, 175);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(938, 361);
            dataGridView1.TabIndex = 205;
            // 
            // Column1
            // 
            Column1.HeaderText = "Qty";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column2.HeaderText = "Name";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.HeaderText = "Price";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column4.HeaderText = "Total";
            Column4.Name = "Column4";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkSlateGray;
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1904, 102);
            panel2.TabIndex = 204;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.DarkSlateGray;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(39, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(84, 84);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 208;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(162, 40);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 205;
            label1.Text = "POS Software";
            // 
            // button1
            // 
            button1.BackColor = Color.Red;
            button1.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button1.Location = new Point(431, 708);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(80, 60);
            button1.TabIndex = 203;
            button1.Text = "DEL";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox9
            // 
            textBox9.Font = new Font("Century Gothic", 20.25F);
            textBox9.Location = new Point(338, 487);
            textBox9.Margin = new Padding(4, 3, 4, 3);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(270, 49);
            textBox9.TabIndex = 201;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(69, 494);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(207, 36);
            label10.TabIndex = 200;
            label10.Text = "Total Amount:";
            // 
            // cash_renderedtxtbox
            // 
            cash_renderedtxtbox.Font = new Font("Century Gothic", 20.25F);
            cash_renderedtxtbox.Location = new Point(338, 295);
            cash_renderedtxtbox.Margin = new Padding(4, 3, 4, 3);
            cash_renderedtxtbox.Multiline = true;
            cash_renderedtxtbox.Name = "cash_renderedtxtbox";
            cash_renderedtxtbox.Size = new Size(270, 49);
            cash_renderedtxtbox.TabIndex = 174;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label30.Location = new Point(69, 297);
            label30.Margin = new Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new Size(241, 36);
            label30.TabIndex = 173;
            label30.Text = "Cash Rendered:";
            // 
            // changetxtbox
            // 
            changetxtbox.Font = new Font("Century Gothic", 20.25F);
            changetxtbox.Location = new Point(338, 382);
            changetxtbox.Margin = new Padding(4, 3, 4, 3);
            changetxtbox.Multiline = true;
            changetxtbox.Name = "changetxtbox";
            changetxtbox.Size = new Size(270, 49);
            changetxtbox.TabIndex = 176;
            // 
            // button21
            // 
            button21.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button21.Location = new Point(343, 775);
            button21.Margin = new Padding(4, 3, 4, 3);
            button21.Name = "button21";
            button21.Size = new Size(80, 60);
            button21.TabIndex = 191;
            button21.Text = "*";
            button21.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label31.Location = new Point(69, 387);
            label31.Margin = new Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new Size(137, 36);
            label31.TabIndex = 175;
            label31.Text = "Change:";
            // 
            // button2
            // 
            button2.BackColor = Color.LimeGreen;
            button2.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(430, 774);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(80, 192);
            button2.TabIndex = 190;
            button2.Text = "E\r\nN\r\nT\r\nE\r\nR\r\n";
            button2.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            button19.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button19.Location = new Point(255, 708);
            button19.Margin = new Padding(4, 3, 4, 3);
            button19.Name = "button19";
            button19.Size = new Size(80, 60);
            button19.TabIndex = 188;
            button19.Text = "9";
            button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            button20.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button20.Location = new Point(343, 907);
            button20.Margin = new Padding(4, 3, 4, 3);
            button20.Name = "button20";
            button20.Size = new Size(80, 60);
            button20.TabIndex = 189;
            button20.Text = "+";
            button20.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            button18.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button18.Location = new Point(167, 775);
            button18.Margin = new Padding(4, 3, 4, 3);
            button18.Name = "button18";
            button18.Size = new Size(80, 60);
            button18.TabIndex = 187;
            button18.Text = "5";
            button18.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            button17.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button17.Location = new Point(343, 841);
            button17.Margin = new Padding(4, 3, 4, 3);
            button17.Name = "button17";
            button17.Size = new Size(80, 60);
            button17.TabIndex = 186;
            button17.Text = "-";
            button17.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            button14.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button14.Location = new Point(167, 708);
            button14.Margin = new Padding(4, 3, 4, 3);
            button14.Name = "button14";
            button14.Size = new Size(80, 60);
            button14.TabIndex = 185;
            button14.Text = "8";
            button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            button13.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button13.Location = new Point(79, 775);
            button13.Margin = new Padding(4, 3, 4, 3);
            button13.Name = "button13";
            button13.Size = new Size(80, 60);
            button13.TabIndex = 184;
            button13.Text = "4";
            button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            button12.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button12.Location = new Point(255, 775);
            button12.Margin = new Padding(4, 3, 4, 3);
            button12.Name = "button12";
            button12.Size = new Size(80, 60);
            button12.TabIndex = 183;
            button12.Text = "6";
            button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            button11.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button11.Location = new Point(167, 841);
            button11.Margin = new Padding(4, 3, 4, 3);
            button11.Name = "button11";
            button11.Size = new Size(80, 60);
            button11.TabIndex = 182;
            button11.Text = "2";
            button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button10.Location = new Point(255, 841);
            button10.Margin = new Padding(4, 3, 4, 3);
            button10.Name = "button10";
            button10.Size = new Size(80, 60);
            button10.TabIndex = 181;
            button10.Text = "3";
            button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            button9.BackColor = Color.Transparent;
            button9.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button9.Location = new Point(79, 708);
            button9.Margin = new Padding(4, 3, 4, 3);
            button9.Name = "button9";
            button9.Size = new Size(80, 60);
            button9.TabIndex = 180;
            button9.Text = "7";
            button9.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button6.Location = new Point(79, 841);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new Size(80, 60);
            button6.TabIndex = 179;
            button6.Text = "1";
            button6.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            button16.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button16.Location = new Point(343, 708);
            button16.Margin = new Padding(4, 3, 4, 3);
            button16.Name = "button16";
            button16.Size = new Size(80, 60);
            button16.TabIndex = 178;
            button16.Text = "/";
            button16.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            button7.Location = new Point(80, 909);
            button7.Margin = new Padding(4, 3, 4, 3);
            button7.Name = "button7";
            button7.Size = new Size(255, 60);
            button7.TabIndex = 177;
            button7.Text = "0";
            button7.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // Cashier_Interface
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Cashier_Interface";
            Text = "Cashier_Interface";
            Load += Cashier_Interface_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private TextBox textBox9;
        private Label label10;
        private TextBox cash_renderedtxtbox;
        private Label label30;
        private TextBox changetxtbox;
        private Button button21;
        private Label label31;
        private Button button2;
        private Button button19;
        private Button button20;
        private Button button18;
        private Button button17;
        private Button button14;
        private Button button13;
        private Button button12;
        private Button button11;
        private Button button10;
        private Button button9;
        private Button button6;
        private Button button16;
        private Button button7;
        private Panel panel2;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Label timeLbl;
        private Label dateLbl;
        private System.Windows.Forms.Timer timer1;
        private PictureBox pictureBox1;
    }
}