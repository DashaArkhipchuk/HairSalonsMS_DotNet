using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNetCoursework.Domain;
using DotNetCoursework.Infrastructure.Services;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;

namespace DotNetCoursework.View
{
    public partial class RegisterForm : Form
    {
        int RoleId { get; set; }

        UserService userService = new UserService();
        RoleService roleService = new RoleService();

        ErrorProvider errorProvider = new ErrorProvider();
        public RegisterForm(int roleId = 4)
        {
            InitializeComponent();

            errorProvider.ContainerControl = this;

            RoleId = roleId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validation.Validation.IsValid(errorProvider))
                return;

            if (!userService.IsEmailInUse(textBoxEmail.Text))
            {
                if (textBoxPassword.Text == textBoxConfirmPassword.Text)
                {
                    User newUser = new User();
                    newUser.Name = $"{textBoxFirsttName.Text}{textBoxLastName.Text}";
                    newUser.Email = textBoxEmail.Text;
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(textBoxPassword.Text);
                    newUser.Password = passwordHash;
                    newUser.Role = roleService.GetRoleById(RoleId) ?? new Role();

                    switch (RoleId) {
                        case (int)AccessLevels.Customer:
                            Customer newCustomer = CreateCustomer();
                            newUser.Customer = newCustomer;

                            break;

                        case (int)AccessLevels.Stylist:
                            Stylist newStylist= CreateStylist();
                            newUser.Stylist = newStylist;

                            break;

                        case (int)AccessLevels.Manager:
                            Manager newManager = CreateManager();
                            newUser.Manager = newManager;

                            break;


                    }
                    userService.AddUser(newUser);




                }
            }

            this.Close();
        }

        private Customer CreateCustomer()
        {
            Customer newCustomer = new Customer();
            newCustomer.FirstName = textBoxFirsttName.Text;
            newCustomer.LastName = textBoxLastName.Text;
            newCustomer.ContactEmail = textBoxEmail.Text;
            newCustomer.ContactPhone = textBoxPhone.Text;
            
            return newCustomer;

        }

        private Manager CreateManager()
        {
            Manager m = new Manager();
            m.FirstName = textBoxFirsttName.Text;
            m.LastName = textBoxLastName.Text;
            m.ContactEmail = textBoxEmail.Text;
            m.ContactPhone = textBoxPhone.Text;

            return m;

        }

        private Stylist CreateStylist()
        {
            Stylist s = new Stylist();
            s.FirstName = textBoxFirsttName.Text;
            s.LastName = textBoxLastName.Text;
            s.ContactEmail = textBoxEmail.Text;
            s.ContactPhone = textBoxPhone.Text;

            return s;

        }

        private void textBoxNotEmpty_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (!Validation.ValidatingMethods.IsStringNotEmpty(textBox.Text))
            {
                errorProvider.SetError(textBox, "Field is Required");
                button1.Enabled = false;
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(textBox, "");
            }
        }

        private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.ValidatingMethods.IsEmailValid(textBoxEmail.Text))
            {
                errorProvider.SetError(textBoxEmail, "Invalid email format");
                button1.Enabled = false;
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(textBoxEmail, "");
                button1.Enabled = true;
            }
        }

        private void textBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!Validation.ValidatingMethods.IsPhoneValid(textBoxPhone.Text))
            {
                errorProvider.SetError(textBoxPhone, "Invalid phone number format");
                button1.Enabled = false;
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(textBoxPhone, "");
                button1.Enabled = true;
            }
        }

        private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox != null)
            {
                if (!Validation.ValidatingMethods.IsPasswordValid(textBox.Text, out string message))
                {
                    errorProvider.SetError(textBox, message);
                    button1.Enabled = false;
                    e.Cancel = true;
                }
                else
                {
                    errorProvider.SetError(textBox, "");
                    button1.Enabled = true;
                }
            }
        }

        private void TextBoxConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!String.Equals(textBoxConfirmPassword.Text, textBoxPassword.Text, StringComparison.Ordinal))
            {
                errorProvider.SetError(textBoxConfirmPassword, "Password is not the same");
                button1.Enabled = false;
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(textBoxConfirmPassword, "");
                button1.Enabled = true;
            }
        }
    }
}
