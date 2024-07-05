namespace DotNetCoursework.View
{
    partial class AddAppointmentForm
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
            comboBoxSalon = new ComboBox();
            comboBoxStylist = new ComboBox();
            comboBoxSchedule = new ComboBox();
            comboBoxCustomer = new ComboBox();
            comboBoxSevice = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            saveButton = new Button();
            SuspendLayout();
            // 
            // comboBoxSalon
            // 
            comboBoxSalon.FormattingEnabled = true;
            comboBoxSalon.Location = new Point(98, 48);
            comboBoxSalon.Name = "comboBoxSalon";
            comboBoxSalon.Size = new Size(121, 23);
            comboBoxSalon.TabIndex = 0;
            comboBoxSalon.SelectedIndexChanged += comboBoxSalon_SelectedIndexChanged;
            comboBoxSalon.Validating += comboBox_Validating;
            // 
            // comboBoxStylist
            // 
            comboBoxStylist.FormattingEnabled = true;
            comboBoxStylist.Location = new Point(98, 90);
            comboBoxStylist.Name = "comboBoxStylist";
            comboBoxStylist.Size = new Size(121, 23);
            comboBoxStylist.TabIndex = 1;
            comboBoxStylist.SelectedIndexChanged += comboBoxStylist_SelectedIndexChanged;
            comboBoxStylist.Validating += comboBox_Validating;
            // 
            // comboBoxSchedule
            // 
            comboBoxSchedule.FormattingEnabled = true;
            comboBoxSchedule.Location = new Point(98, 132);
            comboBoxSchedule.Name = "comboBoxSchedule";
            comboBoxSchedule.Size = new Size(121, 23);
            comboBoxSchedule.TabIndex = 2;
            comboBoxSchedule.Validating += comboBox_Validating;
            // 
            // comboBoxCustomer
            // 
            comboBoxCustomer.FormattingEnabled = true;
            comboBoxCustomer.Location = new Point(98, 175);
            comboBoxCustomer.Name = "comboBoxCustomer";
            comboBoxCustomer.Size = new Size(121, 23);
            comboBoxCustomer.TabIndex = 3;
            comboBoxCustomer.Validating += comboBox_Validating;
            // 
            // comboBoxSevice
            // 
            comboBoxSevice.FormattingEnabled = true;
            comboBoxSevice.Location = new Point(98, 217);
            comboBoxSevice.Name = "comboBoxSevice";
            comboBoxSevice.Size = new Size(121, 23);
            comboBoxSevice.TabIndex = 4;
            comboBoxSevice.Validating += comboBox_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 51);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 5;
            label1.Text = "Salon";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 93);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 6;
            label2.Text = "Stylist";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 135);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 7;
            label3.Text = "Schedule";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 178);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 8;
            label4.Text = "Customer";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 220);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 9;
            label5.Text = "Service";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(86, 266);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(59, 25);
            saveButton.TabIndex = 10;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // AddAppointmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(246, 315);
            Controls.Add(saveButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxSevice);
            Controls.Add(comboBoxCustomer);
            Controls.Add(comboBoxSchedule);
            Controls.Add(comboBoxStylist);
            Controls.Add(comboBoxSalon);
            Name = "AddAppointmentForm";
            Text = "AddAppointmentForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxSalon;
        private ComboBox comboBoxStylist;
        private ComboBox comboBoxSchedule;
        private ComboBox comboBoxCustomer;
        private ComboBox comboBoxSevice;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button saveButton;
    }
}