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
    public partial class BuyerFunctionality : Form
    {
        public BuyerFunctionality()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BuyerAccountInformation form = new BuyerAccountInformation();
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List form = new List();
            form.ShowDialog();
        }
    }
}