using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetCoursework.Domain;
using DotNetCoursework.Infrastructure;
using DotNetCoursework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DotNetCoursework.View
{
    public partial class AddSalonForm : Form
    {
        private SalonService salonService = new SalonService();
        private AddressService addressService = new AddressService();
        private ManagerService managerService = new ManagerService();
        private StylistService stylistService = new StylistService();
        private int Id;

        private ErrorProvider errorProvider1 = new ErrorProvider();

        private Role? loggedInRole = null;
        private User? loggedInUser = null;
        public AddSalonForm()
        {

            InitializeComponent();

            button1.Click += CreateNewSalonClick;
            comboBoxAddress.Items.AddRange(addressService.GetAddressesNotOccupied().ToArray());
            comboBoxAddress.Items.Add("New address");
            listBoxManagers.Items.AddRange(managerService.GetManagers().ToArray());
            listBoxStylists.Items.AddRange(stylistService.GetStylists().ToArray());

            errorProvider1.ContainerControl = this;

        }

        

        public AddSalonForm(int id, Role? loggedInRole, User? loggedInUser) 
        {

            InitializeComponent();


            this.loggedInRole = loggedInRole;
            this.loggedInUser = loggedInUser;

            InitByRole();

            errorProvider1.ContainerControl = this;

            Salon s = salonService.SelectSalonById(id);
            if (s == null) { return; }

            this.Id = id;

            button1.Click += UpdateSalonClick;

            comboBoxAddress.Items.Add(s.Address);
            comboBoxAddress.Items.AddRange(addressService.GetAddressesNotOccupied().ToArray());
            comboBoxAddress.Items.Add("New address");
            listBoxManagers.Items.AddRange(managerService.GetManagers().ToArray());

            listBoxStylists.Items.AddRange(stylistService.GetStylists().ToArray());

            textBoxName.Text = s.Name;
            textBoxDescription.Text = s.Description;
            textBoxEmail.Text = s.ContactEmail;
            textBoxPhone.Text = s.ContactPhone;
            comboBoxAddress.SelectedItem = s.Address;

            s.Managers.Select(sd => listBoxManagers.Items.IndexOf(sd)).Where(i => i >= 0).ToList().ForEach(i => listBoxManagers.SetSelected(i, true));
            s.Stylists.Select(sd => listBoxStylists.Items.IndexOf(sd)).Where(i => i >= 0).ToList().ForEach(i => listBoxStylists.SetSelected(i, true));

        }

        private void InitByRole()
        {
            if (loggedInRole.Id == (int)AccessLevels.Manager)
            {
                listBoxManagers.Hide();
                label6.Hide();
                listBoxStylists.Location = listBoxManagers.Location;
                label7.Location = label6.Location;
            }

        }

        private void CreateNewSalonClick(object sender, EventArgs e)
        {
            if (!Validation.Validation.IsValid(errorProvider1))
                return;

            Salon s = new Salon();
            s.Name = textBoxName.Text;
            s.Description = textBoxDescription.Text;
            s.ContactPhone = textBoxPhone.Text;
            s.ContactEmail = textBoxEmail.Text;

            s.Address = comboBoxAddress.SelectedItem as Address;

            foreach (var item in listBoxManagers.SelectedItems)
            {
                Manager m = item as Manager;
                if (m != null)
                {
                    s.Managers.Add(managerService.SelectManagerById(m.Id));
                }
            }

            foreach (var item in listBoxStylists.SelectedItems)
            {
                Stylist st = item as Stylist;
                if (st != null)
                {
                    s.Stylists.Add(stylistService.SelectStylistById(st.Id));
                }
            }

            salonService.AddSalon(s);
            this.Close();
        }

        private void UpdateSalonClick(object sender, EventArgs e)
        {
            if (!Validation.Validation.IsValid(errorProvider1))
                return;

            Salon s = new Salon();

            s.Name = textBoxName.Text;
            s.Description = textBoxDescription.Text;
            s.Address = comboBoxAddress.SelectedItem as Address;
            s.ContactPhone = textBoxPhone.Text;
            s.ContactEmail = textBoxEmail.Text;
            s.Managers.Clear();
            s.Stylists.Clear();

            foreach (var item in listBoxManagers.SelectedItems)
            {
                Manager m = item as Manager;
                if (m != null)
                {
                    s.Managers.Add(managerService.SelectManagerById(m.Id));
                }
            }

            foreach (var item in listBoxStylists.SelectedItems)
            {
                Stylist st = item as Stylist;
                if (st != null)
                {
                    s.Stylists.Add(stylistService.SelectStylistById(st.Id));
                }
            }

            salonService.UpdateSalon(Id, s);
            this.Close();

        }

        private void comboBoxAddress_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBoxAddress.SelectedItem.ToString() == "New address")
            {
                AddAddressForm addAddressForm = new AddAddressForm();
                addAddressForm.ShowDialog();

                comboBoxAddress.Items.Clear();
                comboBoxAddress.Items.AddRange(addressService.GetAddressesNotOccupied().ToArray());
                comboBoxAddress.Items.Add("New address");
            }
        }

        private void textBoxName_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.ValidatingMethods.IsStringNotEmpty(textBoxName.Text))
            {
                errorProvider1.SetError(textBoxName, "Name is Required");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(textBoxName, "");

            if (Validation.Validation.IsValid(errorProvider1))
            {
                button1.Enabled = true;
            } else
                button1.Enabled=false;
        }

        private void textBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.ValidatingMethods.IsPhoneValid(textBoxPhone.Text))
            {
                errorProvider1.SetError(textBoxPhone, "Invalid phone number format");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxPhone, "");
            }

            if (Validation.Validation.IsValid(errorProvider1))
            {
                button1.Enabled = true;
            }
            else
                button1.Enabled = false;
        }

        private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        {

            if (!Validation.ValidatingMethods.IsEmailValid(textBoxEmail.Text))
            {
                errorProvider1.SetError(textBoxEmail, "Invalid email format");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxEmail, "");
            }

            if (Validation.Validation.IsValid(errorProvider1))
            {
                button1.Enabled = true;
            }
            else
                button1.Enabled = false;
        }

        private void comboBoxAddress_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.ValidatingMethods.IsComboBoxItemSelected(comboBoxAddress))
            {
                errorProvider1.SetError(comboBoxAddress, "No item selected");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(comboBoxAddress, "");

            if (Validation.Validation.IsValid(errorProvider1))
            {
                button1.Enabled = true;
            }
            else
                button1.Enabled = false;
        }
    }
}
