namespace DotNetCoursework.View
{
    partial class AddScheduleForm
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
            datePicker = new DateTimePicker();
            label1 = new Label();
            numericUpDownStartHour = new NumericUpDown();
            label2 = new Label();
            numericUpDownEndHour = new NumericUpDown();
            label3 = new Label();
            comboBoxSalon = new ComboBox();
            label4 = new Label();
            comboBoxStylist = new ComboBox();
            label5 = new Label();
            saveButton = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownStartHour).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEndHour).BeginInit();
            SuspendLayout();
            // 
            // datePicker
            // 
            datePicker.Location = new Point(93, 55);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(145, 23);
            datePicker.TabIndex = 0;
            datePicker.MinDate = DateTime.Now.Date.AddDays(-1);
            datePicker.Validating += DatePicker_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 61);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "Date";
            // 
            // numericUpDownStartHour
            // 
            numericUpDownStartHour.Location = new Point(93, 94);
            numericUpDownStartHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            numericUpDownStartHour.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDownStartHour.Name = "numericUpDownStartHour";
            numericUpDownStartHour.Size = new Size(145, 23);
            numericUpDownStartHour.TabIndex = 2;
            numericUpDownStartHour.Value = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownStartHour.ValueChanged += numericUpDownStartHour_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 96);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 3;
            label2.Text = "Start hour";
            // 
            // numericUpDownEndHour
            // 
            numericUpDownEndHour.Location = new Point(93, 130);
            numericUpDownEndHour.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            numericUpDownEndHour.Minimum = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownEndHour.Name = "numericUpDownEndHour";
            numericUpDownEndHour.Size = new Size(145, 23);
            numericUpDownEndHour.TabIndex = 4;
            numericUpDownEndHour.Value = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDownEndHour.ValueChanged += numericUpDownEndHour_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 132);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 5;
            label3.Text = "End hour";
            // 
            // comboBoxSalon
            // 
            comboBoxSalon.FormattingEnabled = true;
            comboBoxSalon.Location = new Point(93, 166);
            comboBoxSalon.Name = "comboBoxSalon";
            comboBoxSalon.Size = new Size(143, 23);
            comboBoxSalon.TabIndex = 6;
            comboBoxSalon.SelectedValueChanged += comboBoxSalon_SelectedValueChanged;
            comboBoxSalon.Validating += comboBox_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 169);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 7;
            label4.Text = "Salon";
            // 
            // comboBoxStylist
            // 
            comboBoxStylist.FormattingEnabled = true;
            comboBoxStylist.Location = new Point(93, 204);
            comboBoxStylist.Name = "comboBoxStylist";
            comboBoxStylist.Size = new Size(143, 23);
            comboBoxStylist.TabIndex = 8;
            comboBoxStylist.Validating += comboBox_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(39, 207);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 9;
            label5.Text = "Stylist";
            // 
            // saveButton
            // 
            saveButton.Location = new Point(93, 252);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(75, 23);
            saveButton.TabIndex = 10;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            // 
            // AddScheduleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 310);
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            Controls.Add(saveButton);
            Controls.Add(label5);
            Controls.Add(comboBoxStylist);
            Controls.Add(label4);
            Controls.Add(comboBoxSalon);
            Controls.Add(label3);
            Controls.Add(numericUpDownEndHour);
            Controls.Add(label2);
            Controls.Add(numericUpDownStartHour);
            Controls.Add(label1);
            Controls.Add(datePicker);
            Name = "AddScheduleForm";
            Text = "AddScheduleForm";
            ((System.ComponentModel.ISupportInitialize)numericUpDownStartHour).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEndHour).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker datePicker;
        private Label label1;
        private NumericUpDown numericUpDownStartHour;
        private Label label2;
        private NumericUpDown numericUpDownEndHour;
        private Label label3;
        private ComboBox comboBoxSalon;
        private Label label4;
        private ComboBox comboBoxStylist;
        private Label label5;
        private Button saveButton;
    }
}