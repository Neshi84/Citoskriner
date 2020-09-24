namespace Citologija
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jmbg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.jmbgTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.prezimeTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.imeTxt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.izvestajiBtn = new System.Windows.Forms.Button();
            this.PretragaTxtBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ime,
            this.prezime,
            this.jmbg,
            this.delete});
            this.dataGridView1.Location = new System.Drawing.Point(12, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(432, 284);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // ime
            // 
            this.ime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ime.DataPropertyName = "ime";
            this.ime.HeaderText = "Ime";
            this.ime.Name = "ime";
            this.ime.ReadOnly = true;
            // 
            // prezime
            // 
            this.prezime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prezime.DataPropertyName = "prezime";
            this.prezime.HeaderText = "Prezime";
            this.prezime.Name = "prezime";
            this.prezime.ReadOnly = true;
            // 
            // jmbg
            // 
            this.jmbg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.jmbg.DataPropertyName = "jmbg";
            this.jmbg.HeaderText = "JMBG";
            this.jmbg.Name = "jmbg";
            this.jmbg.ReadOnly = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "Obriši";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Obriši";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.jmbgTxt);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.prezimeTxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.imeTxt);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(493, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 174);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Novi pacijent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "JMBG";
            // 
            // jmbgTxt
            // 
            this.jmbgTxt.Location = new System.Drawing.Point(87, 75);
            this.jmbgTxt.Name = "jmbgTxt";
            this.jmbgTxt.Size = new System.Drawing.Size(196, 20);
            this.jmbgTxt.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Prezime";
            // 
            // prezimeTxt
            // 
            this.prezimeTxt.Location = new System.Drawing.Point(87, 49);
            this.prezimeTxt.Name = "prezimeTxt";
            this.prezimeTxt.Size = new System.Drawing.Size(196, 20);
            this.prezimeTxt.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Ime";
            // 
            // imeTxt
            // 
            this.imeTxt.Location = new System.Drawing.Point(87, 23);
            this.imeTxt.Name = "imeTxt";
            this.imeTxt.Size = new System.Drawing.Size(196, 20);
            this.imeTxt.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 41);
            this.button1.TabIndex = 17;
            this.button1.Text = "Sačuvaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // izvestajiBtn
            // 
            this.izvestajiBtn.Location = new System.Drawing.Point(660, 258);
            this.izvestajiBtn.Name = "izvestajiBtn";
            this.izvestajiBtn.Size = new System.Drawing.Size(116, 41);
            this.izvestajiBtn.TabIndex = 18;
            this.izvestajiBtn.Text = "Izveštaji";
            this.izvestajiBtn.UseVisualStyleBackColor = true;
            this.izvestajiBtn.Click += new System.EventHandler(this.izvestajiBtn_Click);
            // 
            // PretragaTxtBox
            // 
            this.PretragaTxtBox.Location = new System.Drawing.Point(12, 173);
            this.PretragaTxtBox.Name = "PretragaTxtBox";
            this.PretragaTxtBox.Size = new System.Drawing.Size(285, 20);
            this.PretragaTxtBox.TabIndex = 19;
            this.PretragaTxtBox.TextChanged += new System.EventHandler(this.PretragaTxtBox_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 22);
            this.button2.TabIndex = 20;
            this.button2.Text = "Podešavanja";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 495);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PretragaTxtBox);
            this.Controls.Add(this.izvestajiBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox jmbgTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox prezimeTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox imeTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn jmbg;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.Button izvestajiBtn;
        private System.Windows.Forms.TextBox PretragaTxtBox;
        private System.Windows.Forms.Button button2;
    }
}

