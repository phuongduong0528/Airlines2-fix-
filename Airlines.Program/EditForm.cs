using Airlines.Program.Controller;
using Airlines.Service.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlines.Program
{
    public partial class EditForm : Form
    {
        public int Sid; //ID of Schedule that need to update
        private ScheduleController scheduleController;
        private ScheduleDto schedule;

        public EditForm()
        {
            InitializeComponent();
        }

        private async void EditForm_Load(object sender, EventArgs e)
        {
            scheduleController = new ScheduleController();
            schedule = await scheduleController.LoadSchedule(Sid);
            fromLbl.Text = $"From: {schedule.From}";
            toLbl.Text = $"To:{schedule.To}";
            aircraftLbl.Text = $"Aircraft: {schedule.AircraftName}";
            dateDtp.Value = DateTime.Parse(schedule.Date);
            timeTxb.Text = schedule.Time;
            economyTxb.Text = schedule.EconomyPrice.ToString();
        }

        private async void updateBtn_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(timeTxb.Text)&& String.IsNullOrEmpty(economyTxb.Text))
            {
                MessageBox.Show("Textbox must not blank");
                return;
            }
            schedule.Date = dateDtp.Value.Date.ToShortDateString();
            TimeSpan temp1;
            if (TimeSpan.TryParse(timeTxb.Text, out temp1))
                schedule.Time = temp1.ToString();
            else
            {
                MessageBox.Show("Wrong time format");
                return;
            }
            decimal temp2;
            if (Decimal.TryParse(economyTxb.Text, out temp2))
                schedule.EconomyPrice = temp2;
            else
            {
                MessageBox.Show("Wrong price format");
                return;
            }
            scheduleController.EditSchedule(schedule);
            this.Close();
        }
    }
}
