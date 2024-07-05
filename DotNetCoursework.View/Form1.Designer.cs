namespace DotNetCoursework.View
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            previousButton = new Button();
            nextButton = new Button();
            label1 = new Label();
            buttonAdd = new Button();
            buttonUpdate = new Button();
            buttonDelete = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            panelUser = new Panel();
            labelUsername = new Label();
            linkLabelLogin = new LinkLabel();
            linkLabelRegister = new LinkLabel();
            linkLabelLogout = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            panelUser.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.GridColor = SystemColors.Window;
            dataGridView1.Location = new Point(12, 89);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(995, 316);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowStateChanged += dataGridView1_RowStateChanged;
            // 
            // previousButton
            // 
            previousButton.Location = new Point(472, 424);
            previousButton.Name = "previousButton";
            previousButton.Size = new Size(41, 39);
            previousButton.TabIndex = 1;
            previousButton.Text = "<";
            previousButton.UseVisualStyleBackColor = true;
            previousButton.Click += previousButton_Click;
            // 
            // nextButton
            // 
            nextButton.Location = new Point(552, 424);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(41, 39);
            nextButton.TabIndex = 2;
            nextButton.Text = ">";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(519, 431);
            label1.Name = "label1";
            label1.Size = new Size(19, 21);
            label1.TabIndex = 3;
            label1.Text = "1";
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(35, 49);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 4;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += addSalon_Click;
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(333, 52);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(75, 23);
            buttonUpdate.TabIndex = 6;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += updateSalon_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(243, 52);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 5;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += deleteSalon_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 49);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1020, 538);
            tabControl1.TabIndex = 7;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1012, 510);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1012, 510);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelUser
            // 
            panelUser.Controls.Add(linkLabelLogout);
            panelUser.Controls.Add(labelUsername);
            panelUser.Controls.Add(linkLabelLogin);
            panelUser.Controls.Add(linkLabelRegister);
            panelUser.Location = new Point(1, -1);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(1020, 47);
            panelUser.TabIndex = 8;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(903, 21);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(93, 15);
            labelUsername.TabIndex = 2;
            labelUsername.Text = "Some Username";
            // 
            // linkLabelLogin
            // 
            linkLabelLogin.AutoSize = true;
            linkLabelLogin.Location = new Point(844, 21);
            linkLabelLogin.Name = "linkLabelLogin";
            linkLabelLogin.Size = new Size(40, 15);
            linkLabelLogin.TabIndex = 1;
            linkLabelLogin.TabStop = true;
            linkLabelLogin.Text = "Log in";
            linkLabelLogin.LinkClicked += linkLabelLogin_LinkClicked;
            // 
            // linkLabelRegister
            // 
            linkLabelRegister.AutoSize = true;
            linkLabelRegister.Location = new Point(768, 21);
            linkLabelRegister.Name = "linkLabelRegister";
            linkLabelRegister.Size = new Size(49, 15);
            linkLabelRegister.TabIndex = 0;
            linkLabelRegister.TabStop = true;
            linkLabelRegister.Text = "Register";
            linkLabelRegister.LinkClicked += linkLabelRegister_LinkClicked;
            // 
            // linkLabelLogout
            // 
            linkLabelLogout.AutoSize = true;
            linkLabelLogout.Location = new Point(697, 22);
            linkLabelLogout.Name = "linkLabelLogout";
            linkLabelLogout.Size = new Size(48, 15);
            linkLabelLogout.TabIndex = 3;
            linkLabelLogout.TabStop = true;
            linkLabelLogout.Text = "Log out";
            linkLabelLogout.LinkClicked += linkLabelLogout_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 585);
            Controls.Add(panelUser);
            Controls.Add(tabControl1);
            Controls.Add(buttonUpdate);
            Controls.Add(buttonDelete);
            Controls.Add(buttonAdd);
            Controls.Add(label1);
            Controls.Add(nextButton);
            Controls.Add(previousButton);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            panelUser.ResumeLayout(false);
            panelUser.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button previousButton;
        private Button nextButton;
        private Label label1;
        private Button buttonAdd;
        private Button buttonUpdate;
        private Button buttonDelete;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panelUser;
        private LinkLabel linkLabelRegister;
        private LinkLabel linkLabelLogin;
        private Label labelUsername;
        private LinkLabel linkLabelLogout;
    }
}
