﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroceryBama
{
    public partial class StoreHomepage : Form
    {
        public StoreHomepage()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FindItem form = new FindItem();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
