using CbnScrapper.Model;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbnScrapper
{
    public class SaveToExcel
    {
        public void saveToExcel(List<Properties> model, string downloadPath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
             using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("Sheet1");

                 
                workSheet.TabColor = System.Drawing.Color.Black;
                workSheet.DefaultRowHeight = 12;

                
                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;

                // Header of the Excel sheet 
                workSheet.Cells[1, 1].Value = "S.No";
                workSheet.Cells[1, 2].Value = "Name";
                workSheet.Cells[1, 3].Value = "Value";

                // Inserting the article data into excel 
                // sheet by using the for each loop 
                // As we have values to the first row  
                // we will start with second row 
                int recordIndex = 2;

                foreach (var security in model)
                {
                    workSheet.Cells[recordIndex, 1].Value = (recordIndex - 1).ToString();
                    workSheet.Cells[recordIndex, 2].Value = security.Name;
                    workSheet.Cells[recordIndex, 3].Value = security.Details;
                    recordIndex++;
                }

                
                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();
                workSheet.Column(3).AutoFit();
 
                string p_strPath = $"{downloadPath}\\cbnsecurities.xlsx";
                

                if (File.Exists(p_strPath))
                    File.Delete(p_strPath);

                FileStream objFileStrm = File.Create(p_strPath);
                objFileStrm.Close();

                
                File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
               
                excel.Dispose();
                
            }
        }
    }
}
