﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Citologija
{
    public partial class UnosRevizija : Form
    {
        public UnosRevizija()
        {
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = DataAccess.UpisRevizija(DataAccess.Id_pacijent,  dateTimePicker1.Value.ToString("yyyy-MM-dd"),richTextBox1.Text);

            if (temp > 0)
            {
                MessageBox.Show("Podaci uspešno sačuvani");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
            this.Close();
        }

       
    }
}
