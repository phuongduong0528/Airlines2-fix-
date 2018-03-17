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
        public List<ScheduleDto> ReadCSV(string input)
        {
            List<ScheduleDto> result = new List<ScheduleDto>();
            ScheduleDto s;
            DateTime timeval = new DateTime();

            FileInfo fileInfo = new FileInfo(input);
            ExcelTextFormat format = new ExcelTextFormat();
            format.Delimiter = ',';
            format.Encoding = new UTF8Encoding();
            format.Culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.ToString());
            format.Culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
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

                    s = new ScheduleDto();

                    if (worksheet.Cells[i, 1].Value.ToString().Equals("ADD"))
                        s.Id = 0;
                    else
                        s.Id = -1;

                    timeval = DateTime.Parse(worksheet.Cells[i, 3].Value.ToString());

                    s.Date = worksheet.Cells[i, 2].Value.ToString();
                    s.Time = timeval.ToShortTimeString();
                    s.FlightNumber = worksheet.Cells[i, 4].Text;
                    s.From = worksheet.Cells[i, 5].Text;
                    s.To = worksheet.Cells[i, 6].Text;
                    try
                    {
                        s.AircraftID = Convert.ToInt32(worksheet.Cells[i, 7].Text);
                        s.EconomyPrice = Convert.ToDecimal(worksheet.Cells[i, 8].Text);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    if (worksheet.Cells[i, 9].Value.ToString().Equals("OK"))
                        s.Confirmed = true;
                    else
                        s.Confirmed = false;
                    result.Add(s);
                }

                package.SaveAs(new FileInfo(Path.GetDirectoryName(input)+"/Output.xlsx"));
            }
            return result; //RETURN LIST
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

