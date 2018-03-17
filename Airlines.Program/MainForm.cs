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
    public partial class MainForm : Form
    {
        ScheduleController scheduleController;
        List<ScheduleDto> schedules;

        public MainForm()
        {
            InitializeComponent();
        }

        public void LoadGridView()
        {
            scheduleDgv.DataSource = schedules;
            for (int i = 0; i < scheduleDgv.RowCount; i++)
            {
                if (scheduleDgv.Rows[i].Cells[10].Value.ToString().Equals("False"))
                {
                    scheduleDgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    scheduleDgv.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                }
                scheduleDgv.Columns[0].Visible = false;
                scheduleDgv.Columns[10].Visible = false;
                scheduleDgv.Columns[11].Visible = false;
                scheduleDgv.Columns[12].Visible = false;
            }
        }

        public async Task RefreshGridView()
        {
            bool desc = false;
            if (descChkbx.Checked)
                desc = true;

            schedules = new List<ScheduleDto>();

            schedules = await scheduleController.LoadListSchedule(
                fromCbx.SelectedItem.ToString(),
                toCbx.SelectedItem.ToString(),
                outboundTxb.Text,
                flightTxb.Text,
                sortCbx.SelectedItem.ToString(),
                desc);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            scheduleController = new ScheduleController();
            List<string> officelist = await scheduleController.GetOffice();
            foreach(string str in officelist)
            {
                fromCbx.Items.Add(str);
                toCbx.Items.Add(str);
            }
            fromCbx.SelectedIndex = 0;
            toCbx.SelectedIndex = 2;
            sortCbx.SelectedIndex = 0;

            await RefreshGridView();
            LoadGridView();
        }

        private async void applyBtn_Click(object sender, EventArgs e)
        {
            await RefreshGridView();
            LoadGridView();
        }

        private async void cancelBtn_Click(object sender, EventArgs e)
        {
            int Id;
            try
            {
                int i = scheduleDgv.CurrentCell.RowIndex;
                Id = Convert.ToInt32(scheduleDgv.Rows[i].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("No selection!");
                return;
            }
            await scheduleController.CancelFlight(Id);
            await RefreshGridView();
            LoadGridView();
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            ImportFile form = new ImportFile();
            form.ShowDialog();
        }

        private async void reloadBtn_Click(object sender, EventArgs e)
        {
            await RefreshGridView();
            LoadGridView();
        }

        private async void editBtn_Click(object sender, EventArgs e)
        {
            int Id;
            try
            {
                int i = scheduleDgv.CurrentCell.RowIndex;
                Id = Convert.ToInt32(scheduleDgv.Rows[i].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("No selection!");
                return;
            }
            EditForm form = new EditForm();
            form.FormClosed += Form_FormClosed;
            form.Sid = Id;
            form.ShowDialog();
            await RefreshGridView();
            LoadGridView();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }
    }
}
