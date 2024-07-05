namespace DotNetCoursework.View
{
    partial class AddSalonForm
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
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBoxAddress = new ComboBox();
            label4 = new Label();
            textBoxPhone = new TextBox();
            label5 = new Label();
            textBoxEmail = new TextBox();
            label6 = new Label();
            label7 = new Label();
            button1 = new Button();
            listBoxManagers = new ListBox();
            listBoxStylists = new ListBox();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(158, 45);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(100, 23);
            textBoxName.TabIndex = 0;
            textBoxName.Validating += textBoxName_Validating;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(158, 74);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(100, 23);
            textBoxDescription.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(92, 53);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 77);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(82, 164);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 5;
            label3.Text = "Address";
            // 
            // comboBoxAddress
            // 
            comboBoxAddress.FormattingEnabled = true;
            comboBoxAddress.Location = new Point(158, 161);
            comboBoxAddress.Name = "comboBoxAddress";
            comboBoxAddress.Size = new Size(121, 23);
            comboBoxAddress.TabIndex = 6;
            comboBoxAddress.SelectedValueChanged += comboBoxAddress_SelectedValueChanged;
            comboBoxAddress.Validating += comboBoxAddress_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 106);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 7;
            label4.Text = "ContactPhone";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(158, 103);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(100, 23);
            textBoxPhone.TabIndex = 8;
            textBoxPhone.Validating += textBoxPhone_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(53, 135);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 9;
            label5.Text = "ContactEmail";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(158, 132);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(100, 23);
            textBoxEmail.TabIndex = 10;
            textBoxEmail.Validating += textBoxEmail_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(72, 193);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 11;
            label6.Text = "Managers";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(82, 293);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 14;
            label7.Text = "Stylists";
            // 
            // button1
            // 
            button1.Location = new Point(136, 399);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 15;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            // 
            // listBoxManagers
            // 
            listBoxManagers.FormattingEnabled = true;
            listBoxManagers.ItemHeight = 15;
            listBoxManagers.Location = new Point(159, 193);
            listBoxManagers.Name = "listBoxManagers";
            listBoxManagers.SelectionMode = SelectionMode.MultiExtended;
            listBoxManagers.Size = new Size(120, 94);
            listBoxManagers.TabIndex = 16;
            // 
            // listBoxStylists
            // 
            listBoxStylists.FormattingEnabled = true;
            listBoxStylists.ItemHeight = 15;
            listBoxStylists.Location = new Point(158, 293);
            listBoxStylists.Name = "listBoxStylists";
            listBoxStylists.SelectionMode = SelectionMode.MultiExtended;
            listBoxStylists.Size = new Size(120, 94);
            listBoxStylists.TabIndex = 17;
            // 
            // AddSalonForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(341, 434);
            Controls.Add(listBoxStylists);
            Controls.Add(listBoxManagers);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBoxEmail);
            Controls.Add(label5);
            Controls.Add(textBoxPhone);
            Controls.Add(label4);
            Controls.Add(comboBoxAddress);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxDescription);
            Controls.Add(textBoxName);
            Name = "AddSalonForm";
            Text = "AddSalonForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxAddress;
        private Label label4;
        private TextBox textBoxPhone;
        private Label label5;
        private TextBox textBoxEmail;
        private Label label6;
        private Label label7;
        private Button button1;
        private ListBox listBoxManagers;
        private ListBox listBoxStylists;
    }
}