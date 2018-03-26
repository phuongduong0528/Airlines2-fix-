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

        public ImportFile()
        {
            InitializeComponent();
        }

        private async void importBtn_Click(object sender, EventArgs e)
        {
            List<ScheduleDto> scheduleDtos = new List<ScheduleDto>();
            CsvReader csvConverter = new CsvReader();

            scheduleDtos = csvConverter.ReadCsv(filepathTxb.Text);
            List<int> result = await Program.Instance.ScheduleController.ImportCsv(scheduleDtos);

            successLbl.Text = $"Success: {result[0]}";
            duplicateLbl.Text = $"Duplicate: {result[1]}";
            failLbl.Text = $"Fail: {result[2]}";
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
