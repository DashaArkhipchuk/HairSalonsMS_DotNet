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
    public partial class AddScheduleForm : Form
    {
        private SalonService salonService = new SalonService();
        private StylistService stylistService = new StylistService();
        private ScheduleService scheduleService = new ScheduleService();

        private int Id;

        private ErrorProvider errorProvider = new ErrorProvider();

        private Role? loggedInRole = null;
        private User? loggedInUser = null;
        public AddScheduleForm(Role? loggedInRole,User? loggedInUser)
        {
            InitializeComponent();

            this.loggedInRole = loggedInRole;
            this.loggedInUser = loggedInUser;


            errorProvider.ContainerControl = this;

            comboBoxSalon.Items.AddRange(salonService.GetSalonsWithNoRelatedData().ToArray());
            comboBoxStylist.Items.AddRange(stylistService.GetStylists().ToArray());
            comboBoxStylist.Enabled = false;

            saveButton.Click += saveNewSchedule_Click;

            InitByRole();
        }

        public AddScheduleForm(int id, Role? loggedInRole, User? loggedInUser)
        {
            InitializeComponent();

            this.loggedInRole = loggedInRole;
            this.loggedInUser = loggedInUser;

            errorProvider.ContainerControl = this;

            comboBoxSalon.Items.AddRange(salonService.GetSalonsWithNoRelatedData().ToArray());

            InitByRole();

            Schedule schedule = scheduleService.GetScheduleById(id);
            if (schedule == null) return;

            this.Id = id;

            datePicker.Value = schedule.Date.ToDateTime(new TimeOnly());
            numericUpDownStartHour.Value = schedule.StartHour;
            numericUpDownEndHour.Value = schedule.EndHour;
            comboBoxSalon.SelectedItem = schedule.Salon;
            comboBoxStylist.Items.Clear();
            comboBoxStylist.Items.AddRange(stylistService.GetStylistsBySalon(schedule.Salon).ToArray());
            comboBoxStylist.SelectedItem = schedule.Stylist;

            saveButton.Click += updateSchedule_Click;

        }

        private void InitByRole()
        {
            switch (loggedInRole?.Id)
            {
                case (int)AccessLevels.Manager:
                    comboBoxSalon.Items.Clear ();
                    comboBoxSalon.Items.AddRange(salonService.GetSalonsByManagerWithNoRelatedData(loggedInUser.Manager.Id).ToArray());
                    break;
                case (int)AccessLevels.Stylist:
                    comboBoxSalon.SelectedValueChanged -= comboBoxSalon_SelectedValueChanged;
                    comboBoxSalon.Items.Clear();
                    comboBoxSalon.Items.AddRange(loggedInUser.Stylist.Salons.Select(s=>salonService.SelectSalonById(s.Id)).ToArray());
                    comboBoxStylist.SelectedItem = stylistService.GetStylistById(loggedInUser.Stylist.Id);
                    comboBoxStylist.Enabled = false;
                    break;

            }
        }

        private void saveNewSchedule_Click(object sender, EventArgs e)
        {
            if (!Validation.Validation.IsValid(errorProvider))
                return;

            Schedule s = new Schedule();
            s.Date = DateOnly.FromDateTime(datePicker.Value.Date);
            s.StartHour = (int)numericUpDownStartHour.Value;
            s.EndHour = (int)numericUpDownEndHour.Value;
            s.Salon = comboBoxSalon.SelectedItem as Salon;
            s.Stylist = comboBoxStylist.SelectedItem as Stylist;

            scheduleService.AddSchedule(s);
            this.Close();
        }

        private void updateSchedule_Click(object sender, EventArgs e)
        {
            if (!Validation.Validation.IsValid(errorProvider))
                return;

            Schedule s = new Schedule();
            s.Date = DateOnly.FromDateTime(datePicker.Value.Date);
            s.StartHour = (int)numericUpDownStartHour.Value;
            s.EndHour = (int)numericUpDownEndHour.Value;
            s.Salon = comboBoxSalon.SelectedItem as Salon;
            s.Stylist = comboBoxStylist.SelectedItem as Stylist;

            scheduleService.UpdateSchedule(Id, s);
            this.Close();
        }

        private void numericUpDownStartHour_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownEndHour.Minimum = numericUpDownStartHour.Value + 1 > numericUpDownEndHour.Maximum ? numericUpDownEndHour.Maximum : numericUpDownStartHour.Value + 1;
        }

        private void numericUpDownEndHour_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownStartHour.Maximum = numericUpDownEndHour.Value - 1 < numericUpDownStartHour.Minimum ? numericUpDownStartHour.Minimum : numericUpDownEndHour.Value - 1;
        }

        private void comboBoxSalon_SelectedValueChanged(object sender, EventArgs e)
        {
            comboBoxStylist.Enabled = true;
            comboBoxStylist.Items.Clear();
            comboBoxStylist.Items.AddRange(stylistService.GetStylistsBySalon(comboBoxSalon.SelectedItem as Salon).ToArray());
        }

        private void DatePicker_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (datePicker.Value <= DateTime.Now)
            {
                errorProvider.SetError(datePicker, "Only future date can be selected");
                saveButton.Enabled = false;
                e.Cancel = true;
            }
            else
                errorProvider.SetError(datePicker, "");

            if (Validation.Validation.IsValid(errorProvider))
            {
                saveButton.Enabled = true;
            }
            else
                saveButton.Enabled = false;

        }
        private void comboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (!Validation.ValidatingMethods.IsComboBoxItemSelected(comboBox))
            {
                errorProvider.SetError(comboBox, "No item selected");
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
    }
}
