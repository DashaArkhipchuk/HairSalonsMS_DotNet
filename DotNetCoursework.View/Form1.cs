using DotNetCoursework.Domain;
using DotNetCoursework.Infrastructure.Services;
using DotNetCoursework.View.Serialization;
using System.Windows.Forms;

namespace DotNetCoursework.View
{
    public partial class Form1 : Form
    {
        private SalonService salonService = new SalonService();
        private ScheduleService scheduleService = new ScheduleService();
        private AppointmentService appointmentService = new AppointmentService();
        private ManagerService managerService = new ManagerService();
        private StylistService stylistService = new StylistService();
        private ServicesService servicesService = new ServicesService();
        private int page = 0;
        private int skip = 0;
        private int take = 5;
        private int selectedTabIndex = 0;
        private int dataGridItemsCount;

        bool loggedIn = false;

        User? loggedInUser;
        Role? loggedInRole;
        public Form1()
        {

            FormData? data = Serialization.Serialization.JsonLoad<FormData>("Serialization.json");
            if (data != null)
            {
                page = data.Page;
                skip = data.Skip;
                take = data.Take;
                selectedTabIndex = data.SelectedTabIndex;
                dataGridItemsCount = data.DataGridItemsCount;
                selectedTabIndex = data.SelectedTabIndex;
                loggedIn = data.LoggedIn;
                loggedInUser = data.LoggedInUser;
                loggedInRole = data.LoggedInRole;
            }

            page = 0;

            InitializeComponent();

            if (loggedIn)
            {
                labelUsername.Text = loggedInUser?.Name;
                linkLabelLogin.Enabled = false;
                linkLabelRegister.Enabled = false;
                linkLabelLogout.Enabled = true;
            }
            else
            {
                linkLabelLogin.Enabled = true;
                linkLabelRegister.Enabled = true;
                linkLabelLogout.Enabled = false;

            }

            if (loggedInRole != null)
            {
                switch (loggedInRole.Id)
                {
                    case (int)AccessLevels.Admin:
                        InitAdmin();
                        break;
                    case (int)AccessLevels.Manager:
                        InitManager();
                        break;
                    case (int)AccessLevels.Stylist:
                        InitStylist();
                        break;
                    case (int)AccessLevels.Customer:
                        InitCustomer();
                        break;


                }
            }



            dataGridView1.DataBindingComplete += (o, _) =>
            {
                var dataGridView = o as DataGridView;
                if (dataGridView != null)
                {
                    dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            };

            InitDataGridView(skip, take, true);

            previousButton.Enabled = false;
            label1.Text = page.ToString();

            buttonDelete.Enabled = false;
            buttonUpdate.Enabled = false;
        }

        void InitAdmin()
        {
            tabControl1.TabPages.Clear();

            Panel panelSalons = new Panel();
            panelSalons.Size = new Size(1012, 556);

            panelSalons.Controls.Add(dataGridView1);
            panelSalons.Controls.Add(buttonAdd);
            panelSalons.Controls.Add(buttonUpdate);
            panelSalons.Controls.Add(buttonDelete);
            panelSalons.Controls.Add(nextButton);
            panelSalons.Controls.Add(previousButton);
            panelSalons.Controls.Add(label1);

            dataGridItemsCount = salonService.GetSalonsCount();

            tabPage1 = new TabPage("Salons");

            tabPage1.Controls.Add(panelSalons);

            tabControl1.TabPages.Add(tabPage1);

            TabPage tabPage2 = new TabPage("Shedules");

            Panel panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage2.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage2);

            TabPage tabPage3 = new TabPage("Appointments");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage3.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage3);

            TabPage tabPage4 = new TabPage("Managers");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage4.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage4);

            TabPage tabPage6 = new TabPage("Stylists");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage6.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage6);

            TabPage tabPage7 = new TabPage("Services");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage7.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage7);

        }

        void InitManager()
        {
            tabControl1.TabPages.Clear();

            Panel panelSalons = new Panel();
            panelSalons.Size = new Size(1012, 556);

            panelSalons.Controls.Add(dataGridView1);
            //panelSalons.Controls.Add(buttonAdd);
            panelSalons.Controls.Add(buttonUpdate);
            panelSalons.Controls.Add(nextButton);
            panelSalons.Controls.Add(previousButton);
            panelSalons.Controls.Add(label1);

            dataGridItemsCount = salonService.GetSalonsCount();

            tabPage1 = new TabPage("Salons");

            tabPage1.Controls.Add(panelSalons);

            tabControl1.TabPages.Add(tabPage1);

            TabPage tabPage2 = new TabPage("Shedules");

            Panel panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage2.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage2);

            TabPage tabPage3 = new TabPage("Appointments");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage3.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage3);

            TabPage tabPage6 = new TabPage("Stylists");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage6.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage6);

            TabPage tabPage7 = new TabPage("Services");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage7.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage7);
        }

        void InitStylistCustomer()
        {
            tabControl1.TabPages.Clear();

            Panel panelSalons = new Panel();
            panelSalons.Size = new Size(1012, 556);

            panelSalons.Controls.Add(dataGridView1);
            panelSalons.Controls.Add(nextButton);
            panelSalons.Controls.Add(previousButton);
            panelSalons.Controls.Add(label1);

            dataGridItemsCount = salonService.GetSalonsCount();

            tabPage1 = new TabPage("Salons");

            tabPage1.Controls.Add(panelSalons);

            tabControl1.TabPages.Add(tabPage1);

            TabPage tabPage2 = new TabPage("Shedules");

            Panel panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage2.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage2);

            TabPage tabPage3 = new TabPage("Appointments");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage3.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage3);

        }

        void InitStylist()
        {
            InitStylistCustomer();
            TabPage tabPage4 = new TabPage("Managers");

            Panel panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage4.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage4);

            TabPage tabPage7 = new TabPage("Services");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage7.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage7);
        }

        void InitCustomer()
        {
            InitStylistCustomer();

            TabPage tabPage4 = new TabPage("Managers");

            Panel panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage4.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage4);

            TabPage tabPage6 = new TabPage("Stylists");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage6.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage6);

            TabPage tabPage7 = new TabPage("Services");

            panel = new Panel();
            panel.Size = new Size(1012, 556);
            tabPage7.Controls.Add(panel);

            tabControl1.TabPages.Add(tabPage7);


        }

        void InitDataGridView(int skip, int take, bool preventWindowRefresh)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    var listSalons = new List<Salon>();
                    if (loggedInRole?.Id == (int)AccessLevels.Manager)
                    {
                        listSalons = salonService.GetSalonsByManager(loggedInUser.Manager.Id, skip, take);
                    }
                    else
                    {
                        listSalons = salonService.GetSalons(skip, take);
                    }

                    switch (loggedInRole?.Id)
                    {
                        case (int)AccessLevels.Stylist:
                            dataGridView1.DataSource = listSalons?.Select(o => new
                            { Id = o.Id, Name = o.Name, Description = o.Description, ContactPhone = o.ContactPhone, ContactEmail = o.ContactEmail, Address = o.Address?.ToString(), Managers = string.Join("\n", o.Managers) })
                            .ToList();

                            break;
                        case (int)AccessLevels.Manager:
                            dataGridView1.DataSource = listSalons?.Select(o => new
                            { Id = o.Id, Name = o.Name, Description = o.Description, ContactPhone = o.ContactPhone, ContactEmail = o.ContactEmail, Address = o.Address?.ToString(), Stylists = string.Join("\n", o.Stylists) })
                          .ToList();

                            break;
                        default:
                            dataGridView1.DataSource = listSalons?.Select(o => new
                            { Id = o.Id, Name = o.Name, Description = o.Description, ContactPhone = o.ContactPhone, ContactEmail = o.ContactEmail, Address = o.Address?.ToString(), Managers = string.Join("\n", o.Managers), Stylists = string.Join("\n", o.Stylists) })
                           .ToList();

                            break;
                    }
                    break;
                case 1:
                    var listSchedules = new List<Schedule>();
                    if (loggedInRole?.Id == (int)AccessLevels.Stylist)
                    {
                        listSchedules = scheduleService.GetSchedulesByStylist(loggedInUser.Stylist.Id);
                    }
                    else if (loggedInRole?.Id == (int)AccessLevels.Manager)
                    {
                        foreach (var items in loggedInUser.Manager.Salons)
                        {
                            listSchedules.AddRange(scheduleService.GetSchedulesBySalon(items.Id));

                        }
                            //loggedInUser?.Manager?.Salons
                            //            .SelectMany(salon => scheduleService.GetSchedulesBySalon(salon.Id))
                            //            .ToList();
                    }
                    else
                    {
                        listSchedules = scheduleService.GetSchedules(skip, take);
                    }
                    var source = listSchedules?.Select(o => new
                    {
                        Id = o.Id,
                        Date = o.Date,
                        Hours = $"{o.StartHour} - {o.EndHour}",
                        Stylist = o.Stylist,
                        Salon = o.Salon.Name,
                        ReservedForCustomer = o.Appointment?.Customer,
                        ReservedForService = o.Appointment?.Service?.Name
                    }).ToList();

                    dataGridView1.DataSource = source;
                    dataGridView1.Refresh();
                    break;
                case 2:
                    var listAppointments = new List<Appointment>();

                    switch(loggedInRole?.Id)
                    {
                        case (int)AccessLevels.Manager:
                            foreach (var items in loggedInUser.Manager.Salons)
                            {
                                listAppointments.AddRange(appointmentService.GetAppointmentsBySalon(items.Id));
                            }
                            //loggedInUser?.Manager?.Salons
                            //        .SelectMany(salon => appointmentService.GetAppointmentsBySalon(salon.Id))
                            //        .ToList();
                            break;
                        case (int)AccessLevels.Stylist:
                            listAppointments = appointmentService.GetAppointmentsByStylist(loggedInUser.Stylist.Id);
                            break;
                        case (int)AccessLevels.Customer:
                            listAppointments = appointmentService.GetAppointmentsByCustomer(loggedInUser.Customer.Id);
                            break;
                        default:
                            listAppointments = appointmentService.GetAppointments(skip, take);
                            break;

                    }
                    dataGridView1.DataSource = listAppointments?.Select(o => new
                    {
                        Id = o.Id,
                        Schedule = $"{o.Schedule.Date} {o.Schedule.StartHour}-{o.Schedule.EndHour}",
                        Customer = o.Customer,
                        Salon = o.Salon,
                        Stylist = o.Stylist,
                        Service = o.Service.Name
                    }).ToList();

                    dataGridView1.Refresh();
                    break;
                case 3:
                    if (loggedInRole?.Id == (int)AccessLevels.Manager)
                    {
                        var listStylist = stylistService.GetStylists(skip, take);
                        dataGridView1.DataSource = listStylist.Select(o => new
                        {
                            Id = o.Id,
                            FirstName = o.FirstName,
                            LastName = o.LastName,
                            Email = o.ContactEmail,
                            Phone = o.ContactPhone,
                            Salons = string.Join("\n", o.Salons)
                        }).ToList();
                    }
                    else
                    {
                        var listManagers = managerService.GetManagers(skip, take);
                        dataGridView1.DataSource = listManagers.Select(o => new
                        {
                            Id = o.Id,
                            FirstName = o.FirstName,
                            LastName = o.LastName,
                            Email = o.ContactEmail,
                            Phone = o.ContactPhone,
                            Salons = string.Join("\n", o.Salons)
                        }).ToList();

                    }

                    dataGridView1.Refresh();
                    break;
                case 4:
                    if (loggedInRole?.Id == (int)AccessLevels.Manager || loggedInRole?.Id == (int)AccessLevels.Stylist)
                    {
                        var listServicess = servicesService.GetServices(skip,take);
                        dataGridView1.DataSource = listServicess?.Select(o => new
                        {
                            Id = o.Id,
                            Name = o.Name,
                            Description = o.Description,
                            Price = o.Price?.Value,
                            Currency = o.Price?.Currency?.Code
                        }).ToList();
                    }
                    else
                    {
                        var listStylists = stylistService.GetStylists(skip, take);
                        dataGridView1.DataSource = listStylists.Select(o => new
                        {
                            Id = o.Id,
                            FirstName = o.FirstName,
                            LastName = o.LastName,
                            Email = o.ContactEmail,
                            Phone = o.ContactPhone,
                            Salons = string.Join("\n", o.Salons)
                        }).ToList();
                    }

                    dataGridView1.Refresh();
                    break;
                case 5:
                    var listServices = servicesService.GetServices(skip,take);
                    dataGridView1.DataSource = listServices?.Select(o => new
                    {
                        Id = o.Id,
                        Name = o.Name,
                        Description = o.Description,
                        Price = o.Price?.Value,
                        Currency = o.Price?.Currency?.Code
                    }).ToList();
                    break;

            }
            dataGridView1.Refresh();


            if (!preventWindowRefresh)
            {
                SerializeFormData();

                Program.KeepRunning = true;
                this.Close();
            }

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if ((page + 1) * take >= dataGridItemsCount)
            {
                nextButton.Enabled = false;
                return;
            }
            page++;
            skip = page * take;
            label1.Text = page.ToString();
            InitDataGridView(skip, take, true);
            if (page > 0)
            {
                previousButton.Enabled = true;
            }
            else
                previousButton.Enabled = false;
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (page == 0)
            {
                previousButton.Enabled = false;
                return;
            }
            page--;
            skip = page * take;
            label1.Text = page.ToString();
            InitDataGridView(skip, take, true);
            if ((page + 1) * take < dataGridItemsCount)
            {
                nextButton.Enabled = true;
            }
            else nextButton.Enabled = false;
        }

        private void addSalon_Click(object sender, EventArgs e)
        {
            AddSalonForm addSalonForm = new AddSalonForm();
            addSalonForm.ShowDialog();
            InitDataGridView(skip, take, false);
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged != DataGridViewElementStates.Selected) { buttonDelete.Enabled = false; buttonUpdate.Enabled = false; return; }
            buttonDelete.Enabled = true;
            buttonUpdate.Enabled = true;

        }

        private void updateSalon_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["Id"].Value;
                AddSalonForm salonForm = new AddSalonForm(id, loggedInRole, loggedInUser);
                salonForm.ShowDialog();
                InitDataGridView(skip, take, false);
                Console.WriteLine(dataGridView1.DataSource);
            }

        }

        private void deleteSalon_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            int id = (int)row.Cells["Id"].Value;

            if (dataGridView1.SelectedRows.Count != 0)
            {
                if (MessageBox.Show($"Are you sure you want to delete the item? \n{salonService.SelectSalonById(id).ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    salonService.RemoveSalon(id);
                    InitDataGridView(skip, take, false);
                }
            }
        }

        private void addSchedule_Click(object sender, EventArgs e)
        {
            AddScheduleForm addScheduleForm = new AddScheduleForm(loggedInRole, loggedInUser);
            addScheduleForm.ShowDialog();
            InitDataGridView(skip, take, false);
        }

        private void updateSchedule_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["Id"].Value;
                AddScheduleForm scheduleForm = new AddScheduleForm(id, loggedInRole, loggedInUser);
                scheduleForm.ShowDialog();
                Thread.Sleep(500);
                InitDataGridView(skip, take, false);
            }

        }

        private void deleteSchedule_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            int id = (int)row.Cells["Id"].Value;

            if (dataGridView1.SelectedRows.Count != 0)
            {
                if (MessageBox.Show($"Are you sure you want to delete the item? \n{scheduleService.GetScheduleById(id).ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    scheduleService.RemoveSchedule(id);
                    InitDataGridView(skip, take, false);
                }
            }
        }

        private void addAppointment_Click(object sender, EventArgs e)
        {
            AddAppointmentForm addAppointmentForm = new AddAppointmentForm(loggedInRole, loggedInUser);
            addAppointmentForm.ShowDialog();
            InitDataGridView(skip, take, false);
        }

        private void updateAppointment_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];
                int id = (int)row.Cells["Id"].Value;
                AddAppointmentForm appointmentForm = new AddAppointmentForm(id, loggedInRole, loggedInUser);
                appointmentForm.ShowDialog();
                InitDataGridView(skip, take, false);
                Console.WriteLine(dataGridView1.DataSource);
            }

        }

        private void deleteAppointment_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            int id = (int)row.Cells["Id"].Value;

            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show($"Are you sure you want to delete the item? \n{appointmentService.GetAppointmentById(id).ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    appointmentService.RemoveAppointment(id);
                    InitDataGridView(skip, take, false);
                }
            }
        }

        private RegisterForm GetRegisterForm(AccessLevels accessLevel)
        {
            return new RegisterForm((int)accessLevel);
        }

        private void AddManager_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = GetRegisterForm(AccessLevels.Manager);
            registerForm.ShowDialog();
            InitDataGridView(skip, take, false);
        }

        private void DeleteManager_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            int id = (int)row.Cells["Id"].Value;

            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show($"Are you sure you want to delete the item? \n{managerService.GetManagerById(id).ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    managerService.RemoveManager(id);
                    InitDataGridView(skip, take, false);
                }
            }
        }

        private void AddStylist_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = GetRegisterForm(AccessLevels.Stylist);
            registerForm.ShowDialog();
            InitDataGridView(skip, take, false);
        }

        private void DeleteStylist_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            int id = (int)row.Cells["Id"].Value;

            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show($"Are you sure you want to delete the item? \n{stylistService.GetStylistById(id).ToString()}", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    stylistService.RemoveStylist(id);
                    InitDataGridView(skip, take, false);
                }
            }
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTabIndex = tabControl1.SelectedIndex;

            if (loggedInRole.Id == (int)AccessLevels.Manager && selectedTabIndex == 3)
            {
                buttonAdd.Enabled = false;
                buttonUpdate.Enabled = false;
                dataGridView1.Enabled = false;
            }
            else
            {
                    buttonAdd.Enabled = true;
                    buttonUpdate.Enabled = true;
                    dataGridView1.Enabled = true;
            }

            if (loggedInRole.Id == (int)AccessLevels.Admin && selectedTabIndex == 3 || selectedTabIndex == 4)
            {
                buttonUpdate.Hide();
            }
            else
            {
                buttonUpdate.Show();
            }

            Panel panel = tabControl1.TabPages[selectedTabIndex].Controls.OfType<Panel>().FirstOrDefault();

            if (panel != null)
            {
                switch (loggedInRole.Id)
                {
                    case (int)AccessLevels.Admin:
                        panel.Controls.Add(dataGridView1);
                        panel.Controls.Add(buttonAdd);
                        panel.Controls.Add(buttonUpdate);
                        panel.Controls.Add(buttonDelete);
                        panel.Controls.Add(nextButton);
                        panel.Controls.Add(previousButton);
                        panel.Controls.Add(label1);
                        break;
                    case (int)AccessLevels.Manager:
                        if (selectedTabIndex != 0)
                        {
                            panel.Controls.Add(dataGridView1);
                            panel.Controls.Add(buttonAdd);
                            panel.Controls.Add(buttonUpdate);
                            panel.Controls.Add(nextButton);
                            panel.Controls.Add(previousButton);
                            panel.Controls.Add(label1);
                        }
                        else
                        {
                            panel.Controls.Add(dataGridView1);
                            panel.Controls.Add(buttonUpdate);
                            panel.Controls.Add(nextButton);
                            panel.Controls.Add(previousButton);
                            panel.Controls.Add(label1);
                        }
                        break;
                    case (int)AccessLevels.Stylist:
                        if (selectedTabIndex != 1)
                        {
                            panel.Controls.Add(dataGridView1);
                            panel.Controls.Add(nextButton);
                            panel.Controls.Add(previousButton);
                            panel.Controls.Add(label1);
                        }
                        else
                        {
                            panel.Controls.Add(dataGridView1);
                            panel.Controls.Add(buttonAdd);
                            panel.Controls.Add(buttonUpdate);
                            panel.Controls.Add(buttonDelete);
                            panel.Controls.Add(nextButton);
                            panel.Controls.Add(previousButton);
                            panel.Controls.Add(label1);
                        }
                        break;
                    case (int)AccessLevels.Customer:
                        if (selectedTabIndex != 2)
                        {
                            panel.Controls.Add(dataGridView1);
                            panel.Controls.Add(nextButton);
                            panel.Controls.Add(previousButton);
                            panel.Controls.Add(label1);
                        }
                        else
                        {
                            panel.Controls.Add(dataGridView1);
                            panel.Controls.Add(buttonAdd);
                            panel.Controls.Add(buttonUpdate);
                            panel.Controls.Add(buttonDelete);
                            panel.Controls.Add(nextButton);
                            panel.Controls.Add(previousButton);
                            panel.Controls.Add(label1);
                        }
                        break;

                }
            }

            page = 0;
            skip = 0;
            nextButton.Enabled = true;
            previousButton.Enabled = false;
            label1.Text = page.ToString();

            buttonAdd.Click -= addSalon_Click;
            buttonUpdate.Click -= updateSalon_Click;
            buttonDelete.Click -= deleteSalon_Click;

            buttonAdd.Click -= addSchedule_Click;
            buttonUpdate.Click -= updateSchedule_Click;
            buttonDelete.Click -= deleteSchedule_Click;

            buttonAdd.Click -= addAppointment_Click;
            buttonUpdate.Click -= updateAppointment_Click;
            buttonDelete.Click -= deleteAppointment_Click;


            buttonAdd.Click -= AddStylist_Click;
            buttonDelete.Click -= DeleteStylist_Click;

            buttonAdd.Click -= AddManager_Click;
            buttonDelete.Click -= DeleteManager_Click;



            switch (selectedTabIndex)
            {
                case 0:

                    if (loggedInRole.Id == (int)AccessLevels.Stylist|| loggedInRole.Id == (int)AccessLevels.Admin|| loggedInRole.Id == (int)AccessLevels.Customer)
                    {

                        dataGridItemsCount = salonService.GetSalonsCount();
                    }
                    else
                    {
                        dataGridItemsCount = salonService.GetSalonsByManagerWithNoRelatedData(loggedInUser.Manager.Id).Count();
                    }
                    buttonAdd.Click += addSalon_Click;
                    buttonUpdate.Click += updateSalon_Click;
                    buttonDelete.Click += deleteSalon_Click;
                    nextButton.Click += nextButton_Click;
                    previousButton.Click += previousButton_Click;

                    break;
                case 1:
                    if (loggedInRole.Id == (int)AccessLevels.Admin || loggedInRole.Id == (int)AccessLevels.Customer)
                    {
                        dataGridItemsCount = scheduleService.GetSchedulesCount();
                    }
                    else if (loggedInRole.Id == (int)AccessLevels.Manager)
                    {
                        dataGridItemsCount = scheduleService.GetSchedulesBySalonsCount(loggedInUser.Manager.Salons.ToList());
                    } else if (loggedInRole.Id == (int)AccessLevels.Stylist)
                    {
                        dataGridItemsCount = scheduleService.GetSchedulesByStylist(loggedInUser.Stylist.Id).Count();
                    }
                    buttonAdd.Click += addSchedule_Click;
                    buttonUpdate.Click += updateSchedule_Click;
                    buttonDelete.Click += deleteSchedule_Click;

                    break;
                case 2:
                    switch (loggedInRole.Id)
                    {
                        case (int)AccessLevels.Admin:
                            dataGridItemsCount = appointmentService.GetAppointmentsCount();
                            break;
                        case (int)AccessLevels.Manager:
                            dataGridItemsCount = appointmentService.GetAppointmentsBySalonsCount(loggedInUser.Manager.Salons.ToList());
                            break;
                        case (int)AccessLevels.Stylist:
                            dataGridItemsCount = appointmentService.GetAppointmentsByStylist(loggedInUser.Stylist.Id).Count();
                            break;
                        case (int)AccessLevels.Customer:
                            dataGridItemsCount = loggedInUser.Customer.Appointments.Count();
                            break;

                    }
                    buttonAdd.Click += addAppointment_Click;
                    buttonUpdate.Click += updateAppointment_Click;
                    buttonDelete.Click += deleteAppointment_Click;

                    break;
                case 3:
                    dataGridItemsCount = managerService.GetManagersCount();
                    buttonAdd.Click += AddManager_Click;
                    //buttonUpdate.Click += updateAppointment_Click;
                    buttonDelete.Click += DeleteManager_Click;

                    break;
                case 4:
                    if (loggedInRole.Id == (int)AccessLevels.Manager|| loggedInRole.Id == (int)AccessLevels.Stylist)
                    {
                        dataGridItemsCount = servicesService.GetServices().Count();

                    }
                    else
                    {

                        dataGridItemsCount = stylistService.GetStylistsCount();
                    }
                    buttonAdd.Click += AddStylist_Click;
                    buttonDelete.Click += DeleteStylist_Click;

                    break;
                case 5:
                    dataGridItemsCount = servicesService.GetServices().Count();
                    //buttonAdd.Click += AddStylist_Click;
                    //buttonDelete.Click += DeleteStylist_Click;
                    break;

            }

            InitDataGridView(skip, take, true);
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();

        }

        public void SerializeFormData()
        {
            var data = new FormData(loggedIn, loggedInUser, loggedInRole, dataGridItemsCount, page, skip, take, selectedTabIndex);

            Serialization.Serialization.JsonSave(data, "Serialization.json");
        }

        private void linkLabelLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                if (loginForm.LoggedInUser != null)
                {
                    loggedIn = true;

                    loggedInUser = loginForm.LoggedInUser;

                    loggedInRole = loggedInUser.Role;
                }
            }

            if (loggedInUser != null)
            {
                loggedInUser.Role.Users = new List<User>();
                if (loggedInUser.Manager != null)
                {
                    loggedInUser.Manager.User = new User();
                }

                if (loggedInUser.Stylist != null)
                {
                    loggedInUser.Stylist.User = new User();
                }

                if (loggedInUser.Customer != null)
                {
                    loggedInUser.Customer.User = new User();
                }
            }

            SerializeFormData();

            Program.KeepRunning = true;
            this.Close();
        }

        private void linkLabelLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (loggedIn)
            {
                loggedInRole = null;
                loggedInUser = null;
                loggedIn = false;
            }
            else
            {
                return;
            }

            SerializeFormData();

            Program.KeepRunning = true;
            this.Close();
        }
    }
}
