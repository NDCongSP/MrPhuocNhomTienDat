using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExportTemplate
{
    public class ExcelHelperCloseXml
    {
        public void ExportTemplate(string filePath, DataTable dt)
        {
            var wbook = new XLWorkbook(filePath);

            var ws = wbook.Worksheet(1);

            ws.Cell(2,1).Value = 123;
            ws.Cell("A3").Value = 100;
            ws.Cell("A4").Value = 100;
            ws.Cell("A5").Value = 100;
            ws.Cell("A6").Value = 100;
            ws.Cell("A7").Value = 100;
            ws.Cell("A8").FormulaA1 = "SUM(A2:A7)";
            ws.Cell("A8").Style.Font.Bold = true;
            ws.Cell("A8").Style.Fill.BackgroundColor = XLColor.Green;
            ws.Range("A2:A7").AddConditionalFormat().WhenNotBetween(50,100).Fill.SetBackgroundColor(XLColor.Red);


            wbook.SaveAs(@"D:\MyCompany\7.SourceCode\3.Projects\MrPhuocCtySonThinhBD\sourceCode\ExportTemplate/test.xlsx");

        }
    }
}
