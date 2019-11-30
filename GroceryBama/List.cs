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
    public partial class List : Form
    {
        List<GROCERYSTORE> stores = new List<GROCERYSTORE>();
        List<ADDRESS> addresses = new List<ADDRESS>();
        int counter = 0;
        int fiveReached = 0;
        bool is_descending = true;
        public List()
        {
            InitializeComponent();
            LoadAll();
            DisplayStores();
        }

        //previous
        private void button2_Click(object sender, EventArgs e)
        {
            if (counter < 5)
            {
                counter = 0;
            }
            else
            {
                counter = counter - counter % 5;
                counter -= 5;
            }
            DisplayStores();
        }
        //next
        private void button1_Click(object sender, EventArgs e)
        {
            if (counter == stores.Count) return;
            DisplayStores();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void LoadAll()
        {
            using (var db = new GroceryBamaEntities3())
            {
                stores = (from u in db.GROCERYSTORE
                         orderby u.store_id
                         select u).ToList();
                addresses = (from a in db.ADDRESS
                             orderby a.id
                             select a).ToList();
            }
        }
        
        private void DisplayStores()
        {
            textAll.Text = "";
            fiveReached = 0;
            comboSelect.Items.Clear();
            for (int i = counter; i < stores.Count; i++)
            {
                if (fiveReached == 5) break;
                ADDRESS store_address = null;
                foreach(ADDRESS item in addresses)
                {
                    if (stores[i].address_id == item.id)
                    {
                        store_address = item;
                        break;
                    }
                }
                textAll.AppendText(String.Format("Store Name: {0} | Address: {1} {2} | Phone: {3} | Hours: {4}-{5}",
                    stores[i].store_name, store_address.house_number, store_address.street, stores[i].phone, stores[i].opening_time, stores[i].closing_time));
                textAll.AppendText(Environment.NewLine);
                textAll.AppendText(Environment.NewLine);
                string comboAdd = "";
                comboAdd += stores[i].store_id;
                comboAdd += " - ";
                comboAdd += stores[i].store_name;
                comboSelect.Items.Add(comboAdd);
                fiveReached++;
                counter++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(comboSelect.Text))
            {
                MessageBox.Show("Please select a store.");
                return;
            }
            string id_store = comboSelect.Text.Split('-')[0];
            id_store.Trim();
            foreach(var item in stores)
            {
                if(item.store_id == Int32.Parse(id_store))
                {
                    Globals.Chosen_Store = item;
                }
            }
            StoreHomepage form = new StoreHomepage();
            this.Close();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            is_descending = !is_descending;
            using (var db = new GroceryBamaEntities3())
            {
                stores.Clear();
                if (!is_descending)
                {
                    stores = (from u in db.GROCERYSTORE
                              orderby u.store_name
                              select u).ToList();
                }
                else
                {
                    stores = (from u in db.GROCERYSTORE
                              orderby u.store_name descending
                              select u).ToList();
                }
            }
            if (counter % 5 == 0) counter -= 5;
            else
            {
                counter -= counter % 5;
            }
            DisplayStores();
        }
    }
}
