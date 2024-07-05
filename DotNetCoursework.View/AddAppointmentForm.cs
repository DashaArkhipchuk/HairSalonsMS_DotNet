using DotNetCoursework.Domain;
using DotNetCoursework.Infrastructure.Services;
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
    public partial class AddAppointmentForm : Form
    {
        private SalonService salonService = new SalonService();
        private StylistService stylistService = new StylistService();
        private ScheduleService scheduleService = new ScheduleService();
        private AppointmentService appointmentService = new AppointmentService();
        private ServicesService servicesService = new ServicesService();
        private CustomerService customerService = new CustomerService();

        private ErrorProvider errorProvider = new ErrorProvider();
        private int id;

        private Role? loggedInRole = null;
        private User? loggedInUser = null;

        public AddAppointmentForm(Role? loggedInRole, User? loggedInUser)
        {
            InitializeComponent();

            this.loggedInRole = loggedInRole;
            this.loggedInUser = loggedInUser;

            errorProvider.ContainerControl = this;

            comboBoxSalon.Items.AddRange(salonService.GetSalonsWithNoRelatedData().ToArray());
            comboBoxCustomer.Items.AddRange(customerService.GetCustomers().ToArray());

            InitByRole();

            comboBoxStylist.Enabled = false;
            comboBoxSchedule.Enabled = false;

            comboBoxSevice.Items.AddRange(servicesService.GetServices().ToArray());


            saveButton.Click += saveNewAppointment_Click;


        }

        public AddAppointmentForm(int id, Role? loggedInRole, User? loggedInUser)
        {
            InitializeComponent();

            errorProvider.ContainerControl = this;

            this.id = id;
            this.loggedInRole = loggedInRole;
            this.loggedInUser = loggedInUser;

            Appointment appointment = appointmentService.GetAppointmentById(id);
            if (appointment == null) return;

            comboBoxSalon.Items.AddRange(salonService.GetSalonsWithNoRelatedData().ToArray());
            comboBoxCustomer.Items.AddRange(customerService.GetCustomers().ToArray());
            InitByRole();
            comboBoxSalon.SelectedItem = appointment.Salon;


            comboBoxStylist.Items.Clear();
            comboBoxStylist.Items.AddRange(stylistService.GetStylistsBySalon(appointment.Salon).ToArray());
            comboBoxStylist.SelectedItem = appointment.Stylist;


            comboBoxSchedule.Items.Clear();
            comboBoxSchedule.Items.Add(scheduleService.GetScheduleById(appointment.ScheduleId));
            comboBoxSchedule.Items.AddRange(scheduleService.GetSchedulesByStylistAndSalon(appointment.Salon, appointment.Stylist).ToArray());
            comboBoxSchedule.SelectedIndex = comboBoxSchedule.Items.IndexOf(appointment.Schedule);

            comboBoxSevice.Items.AddRange(servicesService.GetServices().ToArray());
            comboBoxSevice.SelectedItem = appointment.Service;

            comboBoxCustomer.SelectedItem = appointment.Customer;

            saveButton.Click += updateAppointment_Click;


        }

        private void InitByRole()
        {
            switch (loggedInRole?.Id)
            {
                case (int)AccessLevels.Manager:
                    comboBoxSalon.Items.Clear();
                    comboBoxSalon.Items.AddRange(salonService.GetSalonsByManagerWithNoRelatedData(loggedInUser.Manager.Id).ToArray());
                    break;
                case (int)AccessLevels.Customer:
                    comboBoxCustomer.SelectedItem = customerService.GetCustomerById(loggedInUser.Customer.Id);
                    comboBoxCustomer.Enabled = false;
                    break;

            }
        }

        private void comboBoxSalon_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxStylist.SelectedItem = null;
            comboBoxSchedule.SelectedItem = null;
            comboBoxStylist.Enabled = true;
            comboBoxStylist.Items.Clear();
            comboBoxStylist.Items.AddRange(stylistService.GetStylistsBySalon(comboBoxSalon.SelectedItem as Salon).ToArray());
        }

        private void comboBoxStylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxSchedule.SelectedItem = null;
            comboBoxSchedule.Enabled = true;
            comboBoxSchedule.Items.Clear();
            comboBoxSchedule.Items.AddRange(scheduleService.GetSchedulesByStylistAndSalon(comboBoxSalon.SelectedItem as Salon, comboBoxStylist.SelectedItem as Stylist).ToArray());
            Appointment appointment = appointmentService.GetAppointmentById(id);
            if (appointment == null) return;

            if (comboBoxStylist.SelectedItem != null)
            {
                if (appointment.Stylist.FirstName == (comboBoxStylist.SelectedItem as Stylist).FirstName &&
                    appointment.Stylist.LastName == (comboBoxStylist.SelectedItem as Stylist).LastName &&
                    appointment.Salon.Name == (comboBoxSalon.SelectedItem as Salon).Name)
                {
                    comboBoxSchedule.Items.Add(appointment.Schedule);
                }
            }
        }

        private void comboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (!Validation.ValidatingMethods.IsComboBoxItemSelected(comboBox))
            {
                errorProvider.SetError(comboBox, "No item selected");
                saveButton.Enabled = false;
                e.Cancel = true;
            }
            else
                errorProvider.SetError(comboBox, "");

            if (Validation.Validation.IsValid(errorProvider))
            {
                saveButton.Enabled = true;
            }
            else
                saveButton.Enabled = false;
        }

        private void saveNewAppointment_Click(object sender, EventArgs e)
        {
            if (!Validation.Validation.IsValid(errorProvider))
                return;

            Appointment a = new Appointment();
            a.Salon = comboBoxSalon.SelectedItem as Salon;
            a.Stylist = comboBoxStylist.SelectedItem as Stylist;
            a.Schedule = comboBoxSchedule.SelectedItem as Schedule;
            a.Customer = comboBoxCustomer.SelectedItem as Customer;
            a.Service = comboBoxSevice.SelectedItem as Service;

            appointmentService.AddAppointment(a);
            this.Close();
        }

        private void updateAppointment_Click(object sender, EventArgs e)
        {
            if (!Validation.Validation.IsValid(this.errorProvider))
                return;

            Appointment a = new Appointment();
            a.Salon = comboBoxSalon.SelectedItem as Salon;
            a.Stylist = comboBoxStylist.SelectedItem as Stylist;
            a.Schedule = comboBoxSchedule.SelectedItem as Schedule;
            a.Customer = comboBoxCustomer.SelectedItem as Customer;
            a.Service = comboBoxSevice.SelectedItem as Service;

            appointmentService.UpdateAppointment(id, a);
            this.Close();
        }
    }
}
