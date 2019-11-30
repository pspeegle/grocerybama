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
        List<ADDRESS> addresses = new List<ADDRESS>();
        List<BUYER> buyers = new List<BUYER>();
        List<GROCERYSTORE> stores = new List<GROCERYSTORE>();
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAll();
            //MessageBox.Show(users.Count().ToString());
            bool matchFound = false;
            foreach (var item in users)
            {
                if (txtUsername.Text == item.username && txtPassword.Text == item.password)
                {
                    matchFound = true;
                    Globals.Persistent_Current = item;
                    foreach(var item_buyer in buyers)
                    {
                        if (item.username == item_buyer.username) Globals.Persistent_Buyer = item_buyer;
                    }
                    foreach (var item_store in stores)
                    {
                        if (Globals.Persistent_Buyer.default_store_id == item_store.store_id) Globals.Persistent_Store = item_store;
                    }
                    foreach (var item_address in addresses)
                    {
                        if (Globals.Persistent_Buyer.address == item_address.id) Globals.Persistent_Address = item_address;
                        if (Globals.Persistent_Store.address_id == item_address.id) Globals.Store_Address = item_address;
                    }
                    Globals.Preferred_Credit = "N/A";
                    Globals.Preferred_Routing = "N/A";
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
            using (var db = new GroceryBamaEntities3())
            {
                users = (from d in db.USER
                         orderby d.username
                         select d).ToList();
                addresses = (from a in db.ADDRESS
                             orderby a.id
                             select a).ToList();
                buyers = (from b in db.BUYER
                          orderby b.username
                          select b).ToList();
                stores = (from s in db.GROCERYSTORE
                          orderby s.store_id
                          select s).ToList();
            }
        }
    }
}