using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace LostOrStolenMobiles
{
    public class LostMobile
    {
        public string? Id { get; set; }
        public string? Ovd { get; set; }
        public string? Insert_date { get; set; }
        public string? Nz { get; set; }
        public string? Imei { get; set; }
        public string? Nk { get; set; }
        public string? Dk { get; set; }
    }
    public class DataSet
    {
        private List<LostMobile> losted = new List<LostMobile>();

        public List<LostMobile> GetLosted { get => losted; }

        /// <summary>
        /// Import dataset from xlsx file
        /// </summary>
        /// <param name="file_name">File name</param>
        public void Import_data(string file_name)
        {
            losted.Clear();
            try
            {
                // Open the workbook
                using (var workbook = new XLWorkbook(file_name))
                {
                    // Get the first worksheet in the workbook
                    var worksheet = workbook.Worksheet(1);

                    // Iterate over all rows in the worksheet except header ones
                    foreach (var xlRow in worksheet.RowsUsed().Skip(2))
                    {
                        // New element for list
                        LostMobile status = new LostMobile();

                        status.Id = xlRow.Cell(1).Value.ToString();
                        status.Ovd = xlRow.Cell(2).Value.ToString();
                        status.Insert_date = xlRow.Cell(3).Value.ToString();
                        status.Nz = xlRow.Cell(4).Value.ToString();
                        status.Imei = xlRow.Cell(5).Value.ToString();
                        status.Nk = xlRow.Cell(6).Value.ToString();
                        status.Dk = xlRow.Cell(7).Value.ToString();

                        losted.Add(status);
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Файл зайнятий", "Помилка відкриття");
            }

        }

        /// <summary>
        /// Export dataset to xlsx file
        /// </summary>
        /// <param name="file_name">File name</param>
        public void Export_data(string file_name)
        {
            // Checking if file for saving is chosen
            if (file_name == null) MessageBox.Show("Спочатку відкрийте файл, або збережіть як", "Помилка зберігання");
            else
            {
                try
                {
                    // Open the workbook
                    using (var workbook = new XLWorkbook())
                    {
                        // Get the first worksheet in the workbook
                        var worksheet = workbook.Worksheets.Add("Sheet1");

                        worksheet.Cell(1, 1).Value = "ID";
                        worksheet.Cell(2, 1).Value = "Унікальний ідентифікатор запису";

                        worksheet.Cell(1, 2).Value = "OVD";
                        worksheet.Cell(2, 2).Value = "Назва підрозділу, що зареєстрував інформацію";

                        worksheet.Cell(1, 3).Value = "INSERT_DATE";
                        worksheet.Cell(2, 3).Value = "Дата внесення інформації";

                        worksheet.Cell(1, 4).Value = "NZ";
                        worksheet.Cell(2, 4).Value = "Марка/модель";

                        worksheet.Cell(1, 5).Value = "IMEI";
                        worksheet.Cell(2, 5).Value = "IMEI";

                        worksheet.Cell(1, 6).Value = "NK";
                        worksheet.Cell(2, 6).Value = "Номер реєстрації в журналі єдиного обліку підрозділу, що зареєстрував інформацію";

                        worksheet.Cell(1, 7).Value = "DK";
                        worksheet.Cell(2, 7).Value = "Дата реєстрації в журналі єдиного обліку";

                        // Iterate over all elements of the list
                        for (int i = 0; i < losted.Count; i++)
                        {

                            worksheet.Cell(i + 3, 1).Value = losted[i].Id;
                            worksheet.Cell(i + 3, 2).Value = losted[i].Ovd;
                            worksheet.Cell(i + 3, 3).Value = losted[i].Insert_date;
                            worksheet.Cell(i + 3, 4).Value = losted[i].Nz;
                            worksheet.Cell(i + 3, 5).Value = losted[i].Imei;
                            worksheet.Cell(i + 3, 6).Value = losted[i].Nk;
                            worksheet.Cell(i + 3, 7).Value = losted[i].Dk;

                        }

                        workbook.SaveAs(file_name);
                    }
                }
                catch (Exception )
                {
                    MessageBox.Show("Файл зайнятий", "Помилка зберігання");
                }
            }
        }
    }
}

