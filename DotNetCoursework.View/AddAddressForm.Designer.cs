namespace DotNetCoursework.View
{
    partial class AddAddressForm
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
            textBoxRegion = new TextBox();
            textBoxDestrict = new TextBox();
            textBoxCity = new TextBox();
            textBoxStreet = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // textBoxRegion
            // 
            textBoxRegion.Location = new Point(120, 49);
            textBoxRegion.Name = "textBoxRegion";
            textBoxRegion.Size = new Size(100, 23);
            textBoxRegion.TabIndex = 0;
            textBoxRegion.Validating += textBox_Validating;
            // 
            // textBoxDestrict
            // 
            textBoxDestrict.Location = new Point(120, 87);
            textBoxDestrict.Name = "textBoxDestrict";
            textBoxDestrict.Size = new Size(100, 23);
            textBoxDestrict.TabIndex = 1;
            textBoxDestrict.Validating += textBox_Validating;
            // 
            // textBoxCity
            // 
            textBoxCity.Location = new Point(120, 125);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(100, 23);
            textBoxCity.TabIndex = 2;
            textBoxCity.Validating += textBox_Validating;
            // 
            // textBoxStreet
            // 
            textBoxStreet.Location = new Point(120, 164);
            textBoxStreet.Name = "textBoxStreet";
            textBoxStreet.Size = new Size(100, 23);
            textBoxStreet.TabIndex = 3;
            textBoxStreet.Validating += textBox_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 52);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 4;
            label1.Text = "Region";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(65, 90);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 5;
            label2.Text = "District";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(81, 128);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 6;
            label3.Text = "City";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 167);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 7;
            label4.Text = "Street";
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(120, 218);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 10;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // AddAddressForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(304, 261);
            Controls.Add(buttonSave);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxStreet);
            Controls.Add(textBoxCity);
            Controls.Add(textBoxDestrict);
            Controls.Add(textBoxRegion);
            Name = "AddAddressForm";
            Text = "AddAddressForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxRegion;
        private TextBox textBoxDestrict;
        private TextBox textBoxCity;
        private TextBox textBoxStreet;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonSave;
    }
}