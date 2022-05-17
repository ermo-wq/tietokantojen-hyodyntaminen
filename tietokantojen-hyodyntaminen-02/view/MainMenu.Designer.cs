namespace tietokantojen_hyodyntaminen_02 {
    partial class MainMenu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.insertButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testConnectionToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.authorInfoStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.mittarilukemaTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.moottorinTilavuusTextBox = new System.Windows.Forms.TextBox();
            this.hintaTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.merkkiComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.malliComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.variComboBox = new System.Windows.Forms.ComboBox();
            this.polttoaineComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(12, 358);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(182, 37);
            this.insertButton.TabIndex = 8;
            this.insertButton.Text = "Lisää";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.InsertRecord);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testConnectionToolStrip,
            this.authorInfoStrip});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // testConnectionToolStrip
            // 
            this.testConnectionToolStrip.Name = "testConnectionToolStrip";
            this.testConnectionToolStrip.Size = new System.Drawing.Size(258, 26);
            this.testConnectionToolStrip.Text = "Testaa tietokantayhteyttä";
            this.testConnectionToolStrip.Click += new System.EventHandler(this.TestConnection);
            // 
            // authorInfoStrip
            // 
            this.authorInfoStrip.Name = "authorInfoStrip";
            this.authorInfoStrip.Size = new System.Drawing.Size(258, 26);
            this.authorInfoStrip.Text = "Tietoja tekijästä";
            this.authorInfoStrip.Click += new System.EventHandler(this.AuthorInfo);
            // 
            // mittarilukemaTextBox
            // 
            this.mittarilukemaTextBox.Location = new System.Drawing.Point(12, 31);
            this.mittarilukemaTextBox.Multiline = true;
            this.mittarilukemaTextBox.Name = "mittarilukemaTextBox";
            this.mittarilukemaTextBox.Size = new System.Drawing.Size(157, 33);
            this.mittarilukemaTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(175, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mittarilukema";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // moottorinTilavuusTextBox
            // 
            this.moottorinTilavuusTextBox.Location = new System.Drawing.Point(12, 70);
            this.moottorinTilavuusTextBox.Multiline = true;
            this.moottorinTilavuusTextBox.Name = "moottorinTilavuusTextBox";
            this.moottorinTilavuusTextBox.Size = new System.Drawing.Size(157, 33);
            this.moottorinTilavuusTextBox.TabIndex = 1;
            // 
            // hintaTextBox
            // 
            this.hintaTextBox.Location = new System.Drawing.Point(12, 109);
            this.hintaTextBox.Multiline = true;
            this.hintaTextBox.Name = "hintaTextBox";
            this.hintaTextBox.Size = new System.Drawing.Size(157, 33);
            this.hintaTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(175, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 33);
            this.label2.TabIndex = 7;
            this.label2.Text = "Moottorin tilavuus";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(175, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 33);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hinta";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // merkkiComboBox
            // 
            this.merkkiComboBox.FormattingEnabled = true;
            this.merkkiComboBox.Location = new System.Drawing.Point(12, 186);
            this.merkkiComboBox.Name = "merkkiComboBox";
            this.merkkiComboBox.Size = new System.Drawing.Size(156, 24);
            this.merkkiComboBox.TabIndex = 3;
            this.merkkiComboBox.DropDown += new System.EventHandler(this.LoadCarBrands);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(175, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Merkki";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // malliComboBox
            // 
            this.malliComboBox.FormattingEnabled = true;
            this.malliComboBox.Location = new System.Drawing.Point(12, 216);
            this.malliComboBox.Name = "malliComboBox";
            this.malliComboBox.Size = new System.Drawing.Size(156, 24);
            this.malliComboBox.TabIndex = 4;
            this.malliComboBox.DropDown += new System.EventHandler(this.LoadCarModels);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(175, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Malli";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 303);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(259, 22);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "Rekisteröintipäivämäärä";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(12, 401);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(182, 37);
            this.deleteButton.TabIndex = 9;
            this.deleteButton.Text = "Poista";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteRecord);
            // 
            // variComboBox
            // 
            this.variComboBox.FormattingEnabled = true;
            this.variComboBox.Location = new System.Drawing.Point(268, 186);
            this.variComboBox.Name = "variComboBox";
            this.variComboBox.Size = new System.Drawing.Size(156, 24);
            this.variComboBox.TabIndex = 5;
            this.variComboBox.DropDown += new System.EventHandler(this.LoadColours);
            // 
            // polttoaineComboBox
            // 
            this.polttoaineComboBox.FormattingEnabled = true;
            this.polttoaineComboBox.Location = new System.Drawing.Point(268, 216);
            this.polttoaineComboBox.Name = "polttoaineComboBox";
            this.polttoaineComboBox.Size = new System.Drawing.Size(156, 24);
            this.polttoaineComboBox.TabIndex = 6;
            this.polttoaineComboBox.DropDown += new System.EventHandler(this.LoadGas);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(430, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 24);
            this.label7.TabIndex = 18;
            this.label7.Text = "Väri";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(430, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 24);
            this.label8.TabIndex = 19;
            this.label8.Text = "Polttoaine";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(542, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(391, 131);
            this.dataGridView1.TabIndex = 20;
            this.dataGridView1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 37);
            this.button1.TabIndex = 12;
            this.button1.Text = "Edellinen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.PreviousRecord);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(751, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 37);
            this.button2.TabIndex = 13;
            this.button2.Text = "Seuraava";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.NextRecord);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(200, 358);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(182, 37);
            this.button3.TabIndex = 10;
            this.button3.Text = "Hae";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ShowRecords);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(200, 401);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(182, 37);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "Tyhjää ";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearAllFields);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 450);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.polttoaineComboBox);
            this.Controls.Add(this.variComboBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.malliComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.merkkiComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hintaTextBox);
            this.Controls.Add(this.moottorinTilavuusTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mittarilukemaTextBox);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Autokauppa";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testConnectionToolStrip;
        private System.Windows.Forms.TextBox mittarilukemaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox moottorinTilavuusTextBox;
        private System.Windows.Forms.TextBox hintaTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox merkkiComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox malliComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ComboBox variComboBox;
        private System.Windows.Forms.ComboBox polttoaineComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ToolStripMenuItem authorInfoStrip;
    }
}

