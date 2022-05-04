using System.Collections.Generic;
using OfficeOpenXml;

namespace MVCAssignment2.Services
{
    public class ExportService
    {
        public ExcelPackage ExportToExcel<T>(List<T> lst, string sheetName)
        {
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add(sheetName);
            workSheet.Cells[1, 1].LoadFromCollection(lst, true);
            workSheet.Columns.AutoFit();

            return pck;
        }
    }
}