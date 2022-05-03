using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace MVCAssignment1.Services
{
    public class ExportService
    {
        public static void ExportToExcel<T>(string file, List<T> lst, string sheetName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage pck = new ExcelPackage())
            {
                pck.Workbook.Worksheets.Add(sheetName).Cells[1, 1].LoadFromCollection(lst, true);
                pck.SaveAs(new FileInfo(file));
            }
        }
    }
}