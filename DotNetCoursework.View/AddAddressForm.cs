using DotNetCoursework.Domain;
using DotNetCoursework.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNetCoursework.View
{
    public partial class AddAddressForm : Form
    {
        private AddressService addressService = new AddressService();

        private ErrorProvider errorProvider1 = new ErrorProvider();
        public AddAddressForm()
        {
            InitializeComponent();

            errorProvider1.ContainerControl = this;
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!Validation.Validation.IsValid(errorProvider1))
                return;

            Address a = new Address();
            a.Region = textBoxRegion.Text;
            a.City = textBoxCity.Text;
            a.District = textBoxDestrict.Text;
            a.Street = textBoxStreet.Text;

            addressService.AddAddress(a);

            this.Parent?.Refresh();
            this.Close();

        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!Validation.ValidatingMethods.IsStringNotEmpty(textBox.Text))
            {
                errorProvider1.SetError(textBox, "Field is Required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(textBox, "");

            if (Validation.Validation.IsValid(errorProvider1))
            {
                buttonSave.Enabled = true;
            }
            else
                buttonSave.Enabled = false;
        }
    }
}
