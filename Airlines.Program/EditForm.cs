using Airlines.Program.Controller;
using Airlines.Service.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlines.Program
{
    public partial class EditForm : Form
    {
        public int Sid; //ID of Schedule that need to update
        private ScheduleDto schedule;

        public EditForm()
        {
            InitializeComponent();
        }

        private async void EditForm_Load(object sender, EventArgs e)
        {
            schedule = await Program.Instance.ScheduleController.LoadSchedule(Sid);
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
            schedule.Date = dateDtp.Value.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture);

            TimeSpan temp1;
            if (TimeSpan.TryParseExact(timeTxb.Text, @"HH\:mm", CultureInfo.InvariantCulture, out temp1))
            {
                schedule.Time = temp1.ToString();
            }
            else
            {
                MessageBox.Show("Wrong time format");
                return;
            }

            decimal temp2;
            if (Decimal.TryParse(economyTxb.Text, out temp2))
            {
                schedule.EconomyPrice = temp2;
            }
            else
            {
                MessageBox.Show("Wrong price format");
                return;
            }

            int y = await Program.Instance.ScheduleController
                .FindFlightID(schedule.Date, schedule.FlightNumber); //KIEM TRA BAY CUNG NGAY
            if (y == 0 || y == schedule.Id)
            {
                Program.Instance.ScheduleController
                    .EditSchedule(schedule);
                this.Close();
            }
            else
            {
                MessageBox.Show("Can't have same flightnumber on same day");
            }
        }
    }
}
