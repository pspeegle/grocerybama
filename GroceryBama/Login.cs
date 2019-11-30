using System;
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
    public partial class Login : Form
    {
        List<USER> users = new List<USER>();
        public Login()
        {
            InitializeComponent();
            LoadAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool matchFound = false;
            foreach (var item in users)
            {
                if (txtUsername.Text == item.username && txtPassword.Text == item.password)
                {
                    matchFound = true;
                    BuyerFunctionality form = new BuyerFunctionality();
                    form.ShowDialog();
                    continue;
                }
            }
            if (!matchFound)
            {
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Error: Invalid Login Information.", "GroceryBama Message", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register form = new Register();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Are you sure you want to exit?", "GroceryBama Message", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void LoadAll()
        {
            using (var db = new GroceryBamaEntities2())
            {
                users = (from d in db.USER
                         orderby d.username
                         select d).ToList();
            }
        }
    }
}