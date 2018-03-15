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
    public partial class ImportFile : Form
    {
        ScheduleController scheduleController;

        public ImportFile()
        {
            InitializeComponent();
        }


        private void ImportFile_Load(object sender, EventArgs e)
        {
            scheduleController = new ScheduleController();
        }

        private async void importBtn_Click(object sender, EventArgs e)
        {
            List<ScheduleDto> scheduleDtos = new List<ScheduleDto>();
            CsvReader csvConverter = new CsvReader();

            scheduleDtos = csvConverter.ReadCSV(filepathTxb.Text);
            List<int> result = await scheduleController.ImportCsv(scheduleDtos);

            successLbl.Text = $"Success: {result[0]}";
            failLbl.Text = $"Fail: {result[1]}";
        }

        private void chooseBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filepathTxb.Text = openFileDialog1.FileName;
                importBtn.Enabled = true;
            }
        }
    }
}
