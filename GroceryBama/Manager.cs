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
    public partial class Manager : Form
    {
        List<USER> users = new List<USER>();
        List<SYSTEMINFORMATION> sysinfo = new List<SYSTEMINFORMATION>();
        List<GROCERYSTORE> stores = new List<GROCERYSTORE>();
        USER addUser = new USER();
        MANAGES addManages = new MANAGES();
        
        public Manager()
        {
            InitializeComponent();
            LoadAll();
            LoadCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(textEmail.Text))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textFirst.Text))
            {
                MessageBox.Show("Please enter a first name.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textLast.Text))
            {
                MessageBox.Show("Please enter a last name.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Please enter a password.");
                return;
            }
            if (String.IsNullOrWhiteSpace(textConfirmationCode.Text))
            {
                MessageBox.Show("Please enter a confirmation code.");
                return;
            }
            if (String.IsNullOrWhiteSpace(textPhone.Text))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }
            bool validCode = false;
            foreach (var item in sysinfo)
            {
                //MessageBox.Show(item.user_codes);
                if (item.user_codes == textConfirmationCode.Text) validCode = true;
            }
            if (!validCode)
            {
                MessageBox.Show("Please enter a valid code.");
                return;
            }
            foreach (var item in users)
            {
                if (item.username == textUsername.Text)
                {
                    MessageBox.Show("Your username is taken.");
                    return;
                }
            }
            if (textConfirm.Text != textPassword.Text)
            {
                MessageBox.Show("Your password does not match your confirmation.");
                return;
            }

            if (textPhone.Text.Length != 10 && textPhone.Text.Length != 9)
            {
                MessageBox.Show("Phone number must be 9 or 10 digits long.");
                return;
            }

            if (!textEmail.Text.Contains("@") || !textEmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid email address.");
                return;
            }
            addUser.username = textUsername.Text;
            addUser.password = textPassword.Text;
            addUser.first_name = textFirst.Text;
            addUser.last_name = textLast.Text;
            addUser.email = textEmail.Text;
            addUser.user_type = "manager";
            addManages.username = textUsername.Text;
            string address_store = comboAssignStore.Text.Split('-')[0];
            address_store.Trim();
            //MessageBox.Show(address_store);
            addManages.store_address = Int32.Parse(address_store);
            using (var db = new GroceryBamaEntities3())
            {
                db.USER.Add(addUser);
                db.MANAGES.Add(addManages);
                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException)
                {
                    MessageBox.Show("Something went wrong. You shouldn't ever see this if you're a user.");
                }
            }
            MessageBox.Show("Successfully registered deliverer.");
            this.Close();
        }
        private void LoadAll()
        {
            using (var db = new GroceryBamaEntities3())
            {
                users = (from u in db.USER
                         orderby u.username
                         select u).ToList();
                sysinfo = (from s in db.SYSTEMINFORMATION
                           orderby s.system_id
                           select s).ToList();
                stores = (from st in db.GROCERYSTORE
                          orderby st.store_id
                          select st).ToList();
            }
        }
        private void LoadCombo()
        {
            foreach(var item in stores)
            {
                string addToCombo = "";
                addToCombo += item.address_id;
                addToCombo += " - ";
                addToCombo += item.store_name;
                comboAssignStore.Items.Add(addToCombo);
            }
        }
    }
}
