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
    public partial class RegisterBuyer : Form
    {
        List<USER> users = new List<USER>();
        List<BUYER> buyers = new List<BUYER>();
        List<ADDRESS> addresses = new List<ADDRESS>();
        BUYER addBuyer = new BUYER();
        USER addUser = new USER();
        ADDRESS addAddress = new ADDRESS();

        public RegisterBuyer()
        {
            InitializeComponent();
            LoadAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textAddy.Text))
            {
                MessageBox.Show("Please enter an address.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textCity.Text))
            {
                MessageBox.Show("Please enter a city.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textEmail.Text))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textFirstName.Text))
            {
                MessageBox.Show("Please enter a first name.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textLastName.Text))
            {
                MessageBox.Show("Please enter a last name.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textPassword.Text))
            {
                MessageBox.Show("Please enter a password.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textPhone.Text))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textState.Text))
            {
                MessageBox.Show("Please enter a state.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textUser.Text))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textZip.Text))
            {
                MessageBox.Show("Please enter a zip code.");
                return;
            }

            if (String.IsNullOrWhiteSpace(textStreet.Text))
            {
                MessageBox.Show("Please enter a street.");
                return;
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

            if (textZip.Text.Length != 5)
            {
                MessageBox.Show("Your zip code must be 5 digits long.");
                return;
            }

            if (!textEmail.Text.Contains("@") || !textEmail.Text.Contains("."))
            {
                MessageBox.Show("Invalid email address.");
                return;
            }

            foreach(USER item in users)
            {
                if(item.username == textUser.Text)
                {
                    MessageBox.Show("Your username is taken.");
                    return;
                }
            }
            addUser.username = textUser.Text;
            addUser.password = textPassword.Text;
            addUser.first_name = textFirstName.Text;
            addUser.last_name = textLastName.Text;
            addUser.email = textEmail.Text;
            addUser.user_type = "buyer";
            addBuyer.default_payment = "NULL";
            addBuyer.default_store_id = 1;
            addBuyer.phone = textPhone.Text;
            addBuyer.username = textUser.Text;
            int addyMax = 0;
            foreach(var item in addresses)
            {
                if (item.id > addyMax) addyMax = item.id;
            }
            addyMax++;
            addAddress.id = addyMax;
            addBuyer.address = addyMax;
            addAddress.house_number = textAddy.Text;
            addAddress.street = textStreet.Text;
            addAddress.state = textState.Text;
            addAddress.zip_code = textZip.Text;
            addAddress.city = textCity.Text;

            using (var db = new GroceryBamaEntities3())
            {
                db.USER.Add(addUser);
                db.ADDRESS.Add(addAddress);
                db.BUYER.Add(addBuyer);
                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException)
                {
                    MessageBox.Show("Something went wrong. You shouldn't ever see this if you're a user.");
                }
            }
            MessageBox.Show("Successfully registered buyer.");
            this.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadAll()
        {
            using (var db = new GroceryBamaEntities3())
            {
                users = (from u in db.USER
                         orderby u.username
                         select u).ToList();
                buyers = (from b in db.BUYER
                          orderby b.username
                          select b).ToList();
                addresses = (from a in db.ADDRESS
                             orderby a.id
                             select a).ToList();
            }
        }
    }
}
