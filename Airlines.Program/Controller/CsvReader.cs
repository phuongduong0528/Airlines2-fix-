using Airlines.Service.Dto;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace Airlines.Program.Controller
{
    public class CsvReader
    {
        /// <summary>
        /// Read CSV, Create ScheduleDto and convert file to xlsx
        /// </summary>
        public List<ScheduleDto> ReadCsv(string input)
        {
            List<ScheduleDto> scheduleDtos = new List<ScheduleDto>();
            ScheduleDto scheduleDto;
            DateTime datetimeValueTemp = new DateTime();

            FileInfo fileInfo = new FileInfo(input);
            ExcelTextFormat format = new ExcelTextFormat();
            format.Delimiter = ',';
            format.Encoding = new UTF8Encoding();
            format.Culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.ToString());
            format.Culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Worksheet 1");
                worksheet.Cells["A1"].LoadFromText(fileInfo, format,TableStyles.None,true);

                //FORMAT DATA
                //for (int i = 1; i <= worksheet.Dimension.End.Row; i++)
                //{
                //    worksheet.Cells[i, 2].Style.Numberformat.Format = "YY-MM-DD";
                //    worksheet.Cells[i, 3].Style.Numberformat.Format = "HH:MM";
                //}

                //READ AND CREATE SCHEDULEDTO LIST
                for (int i = 1; i <= worksheet.Dimension.End.Row; i++)
                {

                    if (!ValidateRow(worksheet, i))
                        continue;

                    scheduleDto = new ScheduleDto();

                    if (worksheet.Cells[i, 1].Value.ToString().Equals("ADD"))
                        scheduleDto.Id = 0;
                    else
                        scheduleDto.Id = -1;

                    //timeval = DateTime.Parse(worksheet.Cells[i, 3].Value.ToString());
                    if(DateTime.TryParse(worksheet.Cells[i, 3].Value.ToString(),out datetimeValueTemp))
                    {
                        scheduleDto.Time = datetimeValueTemp.ToShortTimeString();
                    }
                    else
                    {
                        scheduleDto.Time = "";
                    }
                    if(DateTime.TryParse(worksheet.Cells[i, 2].Value.ToString(), out datetimeValueTemp))
                    {
                        scheduleDto.Date = datetimeValueTemp.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        scheduleDto.Date = "";
                    }
                    string test = worksheet.Cells[i, 2].Text;
                    scheduleDto.FlightNumber = worksheet.Cells[i, 4].Text;
                    scheduleDto.From = worksheet.Cells[i, 5].Text;
                    scheduleDto.To = worksheet.Cells[i, 6].Text;
                    scheduleDto.AircraftName = "";
                    try
                    {
                        scheduleDto.AircraftID = Convert.ToInt32(worksheet.Cells[i, 7].Text);
                        scheduleDto.EconomyPrice = Convert.ToDecimal(worksheet.Cells[i, 8].Text);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    if (worksheet.Cells[i, 9].Value.ToString().Equals("OK"))
                        scheduleDto.Confirmed = true;
                    else
                        scheduleDto.Confirmed = false;
                    scheduleDtos.Add(scheduleDto);
                }

                package.SaveAs(new FileInfo(Path.GetDirectoryName(input)+"/Output.xlsx"));
            }
            return scheduleDtos; //RETURN LIST
        }


        //VALIIDATE CSV ROWS
        private bool ValidateRow(ExcelWorksheet worksheet,int row)
        {
            if (worksheet.Cells[row, 9].Value == null)
                return false;

            if (
                !worksheet.Cells[row, 1].Value.ToString().Equals("ADD") &&
                !worksheet.Cells[row, 1].Value.ToString().Equals("EDIT"))
                return false;
            if (
                !worksheet.Cells[row, 9].Value.ToString().Equals("OK") &&
                !worksheet.Cells[row, 9].Value.ToString().Equals("CANCELED"))
                return false;
            return true;
        }


        
    }
}

