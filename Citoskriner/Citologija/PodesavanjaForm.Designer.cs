namespace Citologija
{
    partial class PodesavanjaForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nalaz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.izmeni = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Obrisi = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridHpv = new System.Windows.Forms.DataGridView();
            this.id_hpv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nalaz_hpv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.izmeni_hpv = new System.Windows.Forms.DataGridViewButtonColumn();
            this.obrisi_hpv = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.id_cito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nalaz_cito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.izmeni_cito = new System.Windows.Forms.DataGridViewButtonColumn();
            this.obrisi_cito = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBoxHpv = new System.Windows.Forms.TextBox();
            this.buttonHpv = new System.Windows.Forms.Button();
            this.buttonCito = new System.Windows.Forms.Button();
            this.textBoxCito = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHpv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(124, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Sacuvaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nalaz,
            this.izmeni,
            this.Obrisi});
            this.dataGridView1.Location = new System.Drawing.Point(355, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(303, 156);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Nalaz
            // 
            this.Nalaz.DataPropertyName = "nalaz";
            this.Nalaz.HeaderText = "Nalaz";
            this.Nalaz.Name = "Nalaz";
            this.Nalaz.ReadOnly = true;
            // 
            // izmeni
            // 
            this.izmeni.HeaderText = "Izmeni";
            this.izmeni.Name = "izmeni";
            this.izmeni.ReadOnly = true;
            this.izmeni.Text = "Izmeni";
            this.izmeni.UseColumnTextForButtonValue = true;
            // 
            // Obrisi
            // 
            this.Obrisi.HeaderText = "Obriši";
            this.Obrisi.Name = "Obrisi";
            this.Obrisi.ReadOnly = true;
            this.Obrisi.Text = "Obriši";
            this.Obrisi.UseColumnTextForButtonValue = true;
            // 
            // dataGridHpv
            // 
            this.dataGridHpv.AllowUserToAddRows = false;
            this.dataGridHpv.AllowUserToDeleteRows = false;
            this.dataGridHpv.AllowUserToResizeRows = false;
            this.dataGridHpv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHpv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_hpv,
            this.nalaz_hpv,
            this.izmeni_hpv,
            this.obrisi_hpv});
            this.dataGridHpv.Location = new System.Drawing.Point(355, 213);
            this.dataGridHpv.Name = "dataGridHpv";
            this.dataGridHpv.RowHeadersVisible = false;
            this.dataGridHpv.Size = new System.Drawing.Size(303, 151);
            this.dataGridHpv.TabIndex = 3;
            this.dataGridHpv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridHpv_CellContentClick);
            // 
            // id_hpv
            // 
            this.id_hpv.DataPropertyName = "id";
            this.id_hpv.HeaderText = "Id";
            this.id_hpv.Name = "id_hpv";
            this.id_hpv.Visible = false;
            // 
            // nalaz_hpv
            // 
            this.nalaz_hpv.DataPropertyName = "nalaz";
            this.nalaz_hpv.HeaderText = "Nalaz";
            this.nalaz_hpv.Name = "nalaz_hpv";
            // 
            // izmeni_hpv
            // 
            this.izmeni_hpv.HeaderText = "Izmeni";
            this.izmeni_hpv.Name = "izmeni_hpv";
            this.izmeni_hpv.Text = "Izmeni";
            this.izmeni_hpv.UseColumnTextForButtonValue = true;
            // 
            // obrisi_hpv
            // 
            this.obrisi_hpv.HeaderText = "Obrisi";
            this.obrisi_hpv.Name = "obrisi_hpv";
            this.obrisi_hpv.Text = "Obrisi";
            this.obrisi_hpv.UseColumnTextForButtonValue = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_cito,
            this.nalaz_cito,
            this.izmeni_cito,
            this.obrisi_cito});
            this.dataGridView2.Location = new System.Drawing.Point(355, 388);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.Size = new System.Drawing.Size(303, 146);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // id_cito
            // 
            this.id_cito.DataPropertyName = "id";
            this.id_cito.HeaderText = "Id";
            this.id_cito.Name = "id_cito";
            this.id_cito.ReadOnly = true;
            this.id_cito.Visible = false;
            // 
            // nalaz_cito
            // 
            this.nalaz_cito.DataPropertyName = "nalaz";
            this.nalaz_cito.HeaderText = "Nalaz";
            this.nalaz_cito.Name = "nalaz_cito";
            this.nalaz_cito.ReadOnly = true;
            // 
            // izmeni_cito
            // 
            this.izmeni_cito.HeaderText = "Izmeni";
            this.izmeni_cito.Name = "izmeni_cito";
            this.izmeni_cito.ReadOnly = true;
            this.izmeni_cito.Text = "Izmeni";
            this.izmeni_cito.UseColumnTextForButtonValue = true;
            // 
            // obrisi_cito
            // 
            this.obrisi_cito.HeaderText = "Obrisi";
            this.obrisi_cito.Name = "obrisi_cito";
            this.obrisi_cito.ReadOnly = true;
            this.obrisi_cito.Text = "Obrisi";
            this.obrisi_cito.UseColumnTextForButtonValue = true;
            // 
            // textBoxHpv
            // 
            this.textBoxHpv.Location = new System.Drawing.Point(12, 213);
            this.textBoxHpv.Name = "textBoxHpv";
            this.textBoxHpv.Size = new System.Drawing.Size(124, 20);
            this.textBoxHpv.TabIndex = 5;
            // 
            // buttonHpv
            // 
            this.buttonHpv.Location = new System.Drawing.Point(165, 213);
            this.buttonHpv.Name = "buttonHpv";
            this.buttonHpv.Size = new System.Drawing.Size(114, 23);
            this.buttonHpv.TabIndex = 6;
            this.buttonHpv.Text = "Sacuvaj";
            this.buttonHpv.UseVisualStyleBackColor = true;
            this.buttonHpv.Click += new System.EventHandler(this.buttonHpv_Click);
            // 
            // buttonCito
            // 
            this.buttonCito.Location = new System.Drawing.Point(165, 388);
            this.buttonCito.Name = "buttonCito";
            this.buttonCito.Size = new System.Drawing.Size(114, 23);
            this.buttonCito.TabIndex = 8;
            this.buttonCito.Text = "Sacuvaj";
            this.buttonCito.UseVisualStyleBackColor = true;
            this.buttonCito.Click += new System.EventHandler(this.buttonCito_Click);
            // 
            // textBoxCito
            // 
            this.textBoxCito.Location = new System.Drawing.Point(12, 388);
            this.textBoxCito.Name = "textBoxCito";
            this.textBoxCito.Size = new System.Drawing.Size(124, 20);
            this.textBoxCito.TabIndex = 7;
            // 
            // PodesavanjaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 577);
            this.Controls.Add(this.buttonCito);
            this.Controls.Add(this.textBoxCito);
            this.Controls.Add(this.buttonHpv);
            this.Controls.Add(this.textBoxHpv);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridHpv);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "PodesavanjaForm";
            this.Text = "PodesavanjaForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHpv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nalaz;
        private System.Windows.Forms.DataGridViewButtonColumn izmeni;
        private System.Windows.Forms.DataGridViewButtonColumn Obrisi;
        private System.Windows.Forms.DataGridView dataGridHpv;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_hpv;
        private System.Windows.Forms.DataGridViewTextBoxColumn nalaz_hpv;
        private System.Windows.Forms.DataGridViewButtonColumn izmeni_hpv;
        private System.Windows.Forms.DataGridViewButtonColumn obrisi_hpv;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cito;
        private System.Windows.Forms.DataGridViewTextBoxColumn nalaz_cito;
        private System.Windows.Forms.DataGridViewButtonColumn izmeni_cito;
        private System.Windows.Forms.DataGridViewButtonColumn obrisi_cito;
        private System.Windows.Forms.TextBox textBoxHpv;
        private System.Windows.Forms.Button buttonHpv;
        private System.Windows.Forms.Button buttonCito;
        private System.Windows.Forms.TextBox textBoxCito;
    }
}