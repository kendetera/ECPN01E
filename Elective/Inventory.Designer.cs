namespace Elective
{
    partial class Inventory
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
            panel1 = new Panel();
            button2 = new Button();
            barcodePicturebox = new PictureBox();
            button1 = new Button();
            stocksTxtbox = new TextBox();
            label36 = new Label();
            label26 = new Label();
            label27 = new Label();
            categoryTxtbox = new TextBox();
            label13 = new Label();
            descriptionTxtbox = new TextBox();
            label11 = new Label();
            barcodeTextbox = new TextBox();
            label20 = new Label();
            productpicpathTextbox = new TextBox();
            dataGridView1 = new DataGridView();
            exitBtn = new Button();
            newBtn = new Button();
            deleteBtn = new Button();
            updateBtn = new Button();
            saveBtn = new Button();
            searchBtn = new Button();
            priceTxtbox = new TextBox();
            nameTxtbox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            productPicturebox = new PictureBox();
            manufacturedDate = new DateTimePicker();
            expDate = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)barcodePicturebox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productPicturebox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkSeaGreen;
            panel1.Controls.Add(expDate);
            panel1.Controls.Add(manufacturedDate);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(barcodePicturebox);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(stocksTxtbox);
            panel1.Controls.Add(label36);
            panel1.Controls.Add(label26);
            panel1.Controls.Add(label27);
            panel1.Controls.Add(categoryTxtbox);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(descriptionTxtbox);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(barcodeTextbox);
            panel1.Controls.Add(label20);
            panel1.Controls.Add(productpicpathTextbox);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(exitBtn);
            panel1.Controls.Add(newBtn);
            panel1.Controls.Add(deleteBtn);
            panel1.Controls.Add(updateBtn);
            panel1.Controls.Add(saveBtn);
            panel1.Controls.Add(searchBtn);
            panel1.Controls.Add(priceTxtbox);
            panel1.Controls.Add(nameTxtbox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(productPicturebox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1071, 670);
            panel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(147, 603);
            button2.Name = "button2";
            button2.Size = new Size(159, 39);
            button2.TabIndex = 388;
            button2.Text = "Generate Barcode";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // barcodePicturebox
            // 
            barcodePicturebox.BorderStyle = BorderStyle.Fixed3D;
            barcodePicturebox.Location = new Point(21, 377);
            barcodePicturebox.Name = "barcodePicturebox";
            barcodePicturebox.Size = new Size(406, 206);
            barcodePicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            barcodePicturebox.TabIndex = 387;
            barcodePicturebox.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(147, 315);
            button1.Name = "button1";
            button1.Size = new Size(159, 39);
            button1.TabIndex = 386;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click; // wire the click handler
            // 
            // stocksTxtbox
            // 
            stocksTxtbox.Location = new Point(554, 279);
            stocksTxtbox.Name = "stocksTxtbox";
            stocksTxtbox.Size = new Size(162, 23);
            stocksTxtbox.TabIndex = 385;
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold);
            label36.Location = new Point(450, 278);
            label36.Name = "label36";
            label36.Size = new Size(59, 18);
            label36.TabIndex = 384;
            label36.Text = "Stocks:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold);
            label26.Location = new Point(447, 226);
            label26.Name = "label26";
            label26.Size = new Size(80, 36);
            label26.TabIndex = 382;
            label26.Text = "Expiration\r\nDate:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold);
            label27.Location = new Point(450, 173);
            label27.Name = "label27";
            label27.Size = new Size(116, 36);
            label27.TabIndex = 380;
            label27.Text = "Manufactured \r\nDate:";
            // 
            // categoryTxtbox
            // 
            categoryTxtbox.Location = new Point(554, 144);
            categoryTxtbox.Name = "categoryTxtbox";
            categoryTxtbox.Size = new Size(162, 23);
            categoryTxtbox.TabIndex = 379;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold);
            label13.Location = new Point(450, 143);
            label13.Name = "label13";
            label13.Size = new Size(82, 18);
            label13.TabIndex = 378;
            label13.Text = "Category:";
            // 
            // descriptionTxtbox
            // 
            descriptionTxtbox.Location = new Point(554, 115);
            descriptionTxtbox.Name = "descriptionTxtbox";
            descriptionTxtbox.Size = new Size(162, 23);
            descriptionTxtbox.TabIndex = 377;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold);
            label11.Location = new Point(450, 114);
            label11.Name = "label11";
            label11.Size = new Size(95, 18);
            label11.TabIndex = 376;
            label11.Text = "Description:";
            // 
            // barcodeTextbox
            // 
            barcodeTextbox.Location = new Point(554, 28);
            barcodeTextbox.Name = "barcodeTextbox";
            barcodeTextbox.Size = new Size(165, 23);
            barcodeTextbox.TabIndex = 375;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold);
            label20.Location = new Point(450, 28);
            label20.Name = "label20";
            label20.Size = new Size(76, 18);
            label20.TabIndex = 374;
            label20.Text = "Barcode:";
            // 
            // productpicpathTextbox
            // 
            productpicpathTextbox.Location = new Point(122, 272);
            productpicpathTextbox.Name = "productpicpathTextbox";
            productpicpathTextbox.Size = new Size(211, 23);
            productpicpathTextbox.TabIndex = 373;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(453, 315);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(596, 327);
            dataGridView1.TabIndex = 372;
            // 
            // exitBtn
            // 
            exitBtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitBtn.Location = new Point(754, 253);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(266, 39);
            exitBtn.TabIndex = 371;
            exitBtn.Text = "EXIT";
            exitBtn.UseVisualStyleBackColor = true;
            // 
            // newBtn
            // 
            newBtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newBtn.Location = new Point(754, 208);
            newBtn.Name = "newBtn";
            newBtn.Size = new Size(266, 39);
            newBtn.TabIndex = 370;
            newBtn.Text = "NEW / CANCEL";
            newBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deleteBtn.Location = new Point(754, 163);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(266, 39);
            deleteBtn.TabIndex = 369;
            deleteBtn.Text = "DELETE";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // updateBtn
            // 
            updateBtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            updateBtn.Location = new Point(754, 118);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(266, 39);
            updateBtn.TabIndex = 368;
            updateBtn.Text = "UPDATE";
            updateBtn.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            saveBtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            saveBtn.Location = new Point(754, 73);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(266, 39);
            saveBtn.TabIndex = 367;
            saveBtn.Text = "SAVE";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // searchBtn
            // 
            searchBtn.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBtn.Location = new Point(754, 28);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(266, 39);
            searchBtn.TabIndex = 366;
            searchBtn.Text = "SEARCH";
            searchBtn.UseVisualStyleBackColor = true;
            // 
            // priceTxtbox
            // 
            priceTxtbox.Location = new Point(554, 86);
            priceTxtbox.Name = "priceTxtbox";
            priceTxtbox.Size = new Size(165, 23);
            priceTxtbox.TabIndex = 365;
            // 
            // nameTxtbox
            // 
            nameTxtbox.Location = new Point(554, 57);
            nameTxtbox.Name = "nameTxtbox";
            nameTxtbox.Size = new Size(165, 23);
            nameTxtbox.TabIndex = 364;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold);
            label2.Location = new Point(450, 85);
            label2.Name = "label2";
            label2.Size = new Size(49, 18);
            label2.TabIndex = 363;
            label2.Text = "Price:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold);
            label1.Location = new Point(450, 56);
            label1.Name = "label1";
            label1.Size = new Size(57, 18);
            label1.TabIndex = 362;
            label1.Text = "Name:";
            // 
            // productPicturebox
            // 
            productPicturebox.BorderStyle = BorderStyle.Fixed3D;
            productPicturebox.Location = new Point(21, 28);
            productPicturebox.Name = "productPicturebox";
            productPicturebox.Size = new Size(406, 281);
            productPicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            productPicturebox.TabIndex = 361;
            productPicturebox.TabStop = false;
            // 
            // manufacturedDate
            // 
            manufacturedDate.Location = new Point(554, 193);
            manufacturedDate.Name = "manufacturedDate";
            manufacturedDate.Size = new Size(165, 23);
            manufacturedDate.TabIndex = 389;
            // 
            // expDate
            // 
            expDate.Location = new Point(554, 236);
            expDate.Name = "expDate";
            expDate.Size = new Size(165, 23);
            expDate.TabIndex = 390;
            // 
            // Inventory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 670);
            Controls.Add(panel1);
            Name = "Inventory";
            Text = "Inventory";
            Load += Inventory_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)barcodePicturebox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)productPicturebox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private PictureBox barcodePicturebox;
        private Button button1;
        private TextBox stocksTxtbox;
        private Label label36;
        private Label label26;
        private Label label27;
        private TextBox categoryTxtbox;
        private Label label13;
        private TextBox descriptionTxtbox;
        private Label label11;
        private TextBox barcodeTextbox;
        private Label label20;
        private TextBox productpicpathTextbox;
        private DataGridView dataGridView1;
        private Button exitBtn;
        private Button newBtn;
        private Button deleteBtn;
        private Button updateBtn;
        private Button saveBtn;
        private Button searchBtn;
        private TextBox priceTxtbox;
        private TextBox nameTxtbox;
        private Label label2;
        private Label label1;
        private PictureBox productPicturebox;
        private DateTimePicker expDate;
        private DateTimePicker manufacturedDate;
    }
}