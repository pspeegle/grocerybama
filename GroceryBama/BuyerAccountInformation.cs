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
    public partial class BuyerAccountInformation : Form
    {
        public BuyerAccountInformation()
        {
            InitializeComponent();
            LoadText();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void LoadText()
        {
            textAddress.Text = Globals.Persistent_Address.house_number + " " + Globals.Persistent_Address.street;
            textCity.Text = Globals.Persistent_Address.city;
            textEmail.Text = Globals.Persistent_Current.email;
            textFirstName.Text = Globals.Persistent_Current.first_name;
            textLastName.Text = Globals.Persistent_Current.last_name;
            textPhone.Text = Globals.Persistent_Buyer.phone;
            textCreditCardNumber.Text = Globals.Preferred_Credit;
            textPreferredStore.Text = Globals.Persistent_Store.store_name;
            textRoutingNumber.Text = Globals.Preferred_Routing;
            textState.Text = Globals.Persistent_Address.state;
            textStoreAddress.Text = Globals.Store_Address.house_number + " " + Globals.Store_Address.street;
            textUsername.Text = Globals.Persistent_Current.username;
            textZip.Text = Globals.Persistent_Address.zip_code;
        }
    }
}
