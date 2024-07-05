namespace DotNetCoursework.View
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxEmail = new TextBox();
            textBoxPassword = new TextBox();
            textBoxConfirmPassword = new TextBox();
            textBoxPhone = new TextBox();
            textBoxFirsttName = new TextBox();
            textBoxLastName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(153, 146);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 23);
            textBoxEmail.TabIndex = 0;
            textBoxEmail.Validating += textBoxEmail_Validating;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(153, 234);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(100, 23);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxPassword.Validating += textBoxPassword_Validating;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.Location = new Point(153, 278);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(100, 23);
            textBoxConfirmPassword.TabIndex = 2;
            textBoxConfirmPassword.UseSystemPasswordChar = true;
            textBoxConfirmPassword.Validating += TextBoxConfirmPassword_Validating;
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(153, 191);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(100, 23);
            textBoxPhone.TabIndex = 3;
            textBoxPhone.Validating += textBoxPhone_Validating;
            // 
            // textBoxFirsttName
            // 
            textBoxFirsttName.Location = new Point(153, 63);
            textBoxFirsttName.Name = "textBoxFirsttName";
            textBoxFirsttName.Size = new Size(100, 23);
            textBoxFirsttName.TabIndex = 4;
            textBoxFirsttName.Validating += textBoxNotEmpty_Validating;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(153, 104);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(100, 23);
            textBoxLastName.TabIndex = 5;
            textBoxLastName.Validating += textBoxNotEmpty_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 66);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 6;
            label1.Text = "First name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 107);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 7;
            label2.Text = "Last name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 149);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 8;
            label3.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(74, 237);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 9;
            label4.Text = "Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 281);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 10;
            label5.Text = "Confirm password:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(45, 194);
            label6.Name = "label6";
            label6.Size = new Size(89, 15);
            label6.TabIndex = 11;
            label6.Text = "Phone number:";
            // 
            // button1
            // 
            button1.Location = new Point(126, 335);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Register";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(349, 385);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxLastName);
            Controls.Add(textBoxFirsttName);
            Controls.Add(textBoxPhone);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxEmail);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private TextBox textBoxConfirmPassword;
        private TextBox textBoxPhone;
        private TextBox textBoxFirsttName;
        private TextBox textBoxLastName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button button1;
    }
}