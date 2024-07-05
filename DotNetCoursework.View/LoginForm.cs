using DotNetCoursework.Infrastructure.Services;
using DotNetCoursework.Domain;
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
    public partial class LoginForm : Form
    {
        UserService userService = new UserService();


        ErrorProvider errorProvider = new ErrorProvider();

        public User LoggedInUser { get; set; }


        public LoginForm()
        {
            InitializeComponent();
            errorProvider.ContainerControl = this;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Validation.Validation.IsValid(errorProvider))
                return;


            var user = userService.GetUserByEmail(textBoxEmail.Text);
            if (user != null)
            {
                var passwordHash = user.Password;
                bool verified = BCrypt.Net.BCrypt.Verify(textBoxPassword.Text, passwordHash);

                if (verified)
                {
                    this.LoggedInUser = user;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid password");
                }
            }
            else
            {
                MessageBox.Show("This email is not used by any account. Please register first");
            }



        }
    }
}
