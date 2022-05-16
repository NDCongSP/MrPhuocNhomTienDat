using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace DemoPhucThinh
{
    public class ReadWriteExcel
    {
        public DataTable ReadExcelSheet1(string fname, bool firstRowIsHeader, string sheetName)
        {
            List<string> Headers = new List<string>();
            DataTable dt = new DataTable();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fname, false))
            {
                Worksheet worksheet = GetWorksheetByName(doc, sheetName);
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                int counter = 0;
                foreach (Row row in rows)
                {
                    counter = counter + 1;
                    //Read the first row as header
                    if (counter == 1)
                    {
                        var j = 1;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            var colunmName = firstRowIsHeader ? GetCellValue(doc, cell) : "Field" + j++;
                            Debug.WriteLine(colunmName);
                            Headers.Add(colunmName);
                            dt.Columns.Add(colunmName);
                        }
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = GetCellValue(doc, cell);
                            i++;
                        }
                    }
                }

            }
            return dt;
        }
        public Worksheet GetWorksheetByName(SpreadsheetDocument document, string sheetName)
        {
            IEnumerable<Sheet> sheets =
               document.WorkbookPart.Workbook.GetFirstChild<Sheets>().
               Elements<Sheet>().Where(s => s.Name == sheetName);

            if (sheets?.Count() == 0)
            {
                // The specified worksheet does not exist.

                return null;
            }

            string relationshipId = sheets?.First().Id.Value;

            WorksheetPart worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(relationshipId);

            return worksheetPart.Worksheet;
        }


        public DataTable ReadExcelSheet(string fname, bool firstRowIsHeader)
        {
            List<string> Headers = new List<string>();
            DataTable dt = new DataTable();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fname, false))
            {
                //Read the first Sheets 
                Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                int counter = 0;
                foreach (Row row in rows)
                {
                    counter = counter + 1;
                    //Read the first row as header
                    if (counter == 1)
                    {
                        var j = 1;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            var colunmName = firstRowIsHeader ? GetCellValue(doc, cell) : "Field" + j++;
                            Debug.WriteLine(colunmName);
                            Headers.Add(colunmName);
                            dt.Columns.Add(colunmName);
                        }
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach (Cell cell in row.Descendants<Cell>())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = GetCellValue(doc, cell);
                            i++;
                        }
                    }
                }

            }
            return dt;
        }

        public string GetCellValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            return value;
        }

        public void UpdateCell(string docName, string sheetName, List<LimitSettingsModel> data)
        {
            // Open the document for editing.
            using (SpreadsheetDocument doc =
                     SpreadsheetDocument.Open(docName, true))
            {
                Worksheet worksheet = GetWorksheetByName(doc, sheetName);

                if (worksheet != null)
                {
                    uint _rowIndex = 0;
                    string _columnName = "";

                    foreach (var item in data)
                    {
                        switch (item.Parametters)
                        {
                            case "DuongKinh":
                                _rowIndex = 2;
                                break;
                            case "NDNuocNhomTrongLo":
                                _rowIndex = 3;
                                break;
                            case "NDNhomTruocKhuon":
                                _rowIndex = 4;
                                break;
                            case "NDNhomTaiMiengLo":
                                _rowIndex = 5;
                                break;
                            case "NDNuocGiaiNhietMam":
                                _rowIndex = 6;
                                break;
                            case "NDNuocMatGieng":
                                _rowIndex = 7;
                                break;
                            case "NDKhongKhiTrongLo":
                                _rowIndex = 8;
                                break;
                            case "ApLucNuocL1":
                                _rowIndex = 9;
                                break;
                            case "VanTocSoiTitan":
                                _rowIndex = 10;
                                break;
                            case "TocDoCayKhuay":
                                _rowIndex = 11;
                                break;
                            case "ApKhiArgon":
                                _rowIndex = 12;
                                break;
                            case "VanTocXuongMam":
                                _rowIndex = 13;
                                break;
                            case "ChieuDaiPhoi":
                                _rowIndex = 14;
                                break;
                            case "ThoiGianDongDac":
                                _rowIndex = 15;
                                break;
                            case "TanSoXuongMam":
                                _rowIndex = 16;
                                break;
                            case "TanSoBomNuoc":
                                _rowIndex = 17;
                                break;
                            default:
                                break;
                        }

                        Cell cell = GetCell(worksheet,
                                            "B", _rowIndex);

                        cell.CellValue = new CellValue(item.Min.ToString());
                        cell.DataType =
                            new EnumValue<CellValues>(CellValues.Number);

                        cell = GetCell(worksheet,
                                            "C", _rowIndex);

                        cell.CellValue = new CellValue(item.Max.ToString());
                        cell.DataType =
                            new EnumValue<CellValues>(CellValues.Number);
                    }


                    // Save the worksheet.
                    worksheet.Save();
                }
            }

        }

        // Given a worksheet, a column name, and a row index, 
        // gets the cell at the specified column and 
        private Cell GetCell(Worksheet worksheet,
                  string columnName, uint rowIndex)
        {
            Row row = GetRow(worksheet, rowIndex);

            if (row == null)
                return null;

            return row.Elements<Cell>().Where(c => string.Compare
                   (c.CellReference.Value, columnName +
                   rowIndex, true) == 0).First();
        }


        // Given a worksheet and a row index, return the row.
        private Row GetRow(Worksheet worksheet, uint rowIndex)
        {
            return worksheet.GetFirstChild<SheetData>().
              Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }


        public void CreateExcelFile(DataTable table, string partFile)
        {
            using (var workbook = SpreadsheetDocument.Create(partFile, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = workbook.AddWorkbookPart();

                workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                //foreach (System.Data.DataTable table in ds.Tables)
                //{

                var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                uint sheetId = 1;
                if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                {
                    sheetId =
                        sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                }

                DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = "MySheet" };
                sheets.Append(sheet);

                DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                //create HeaderRow
                List<String> columns = new List<string>();
                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);

                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                //add dataRow
                foreach (System.Data.DataRow dsrow in table.Rows)
                {
                    DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                    foreach (String col in columns)
                    {
                        DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();

                        //config type for column
                        if (col == "NhietDoNuocNhomTrongLo" || col == "NhietDoNhomTruocKhuon" || col == "NhietDoNhomCuoiKhuon"
                            || col == "NhietDoNuocGiaiNhietMam" || col == "NhietDoNuocMatGieng" || col == "NhietDoKhongKhiTrongLo"
                            || col == "ApLucNuocL1" || col == "ApLucNuocL2" || col == "TocDoCayKhuay"
                            || col == "ApKhiArgon" || col == "VanTocXuongMam" || col == "ChieuDaiPhoi" || col == "ThoiGianDongDac"
                            || col == "TanSoXuongMam" || col == "TanSoBomNuoc")
                        {
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Number;
                        }
                        else if (col == "DateTime")
                        {
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.Date;
                        }
                        else
                        {
                            cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                        }


                        cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString()); //
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }

                workbook.Close();
            }
        }

        /// <summary>
        /// Dùng Close XML.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="dt"></param>
        public void ExportTemplate(string filePath, DataTable dt)
        {
            //LƯU Ý: index trong excel bắt đầu từ 1
            int startRowIndex = 2;
            int stopRowIndex = startRowIndex + dt.Rows.Count - 1;

            List<string> colDt = new List<string>();

            foreach (DataColumn item in dt.Columns)
            {
                colDt.Add(item.ColumnName);
            }

            var wbook = new XLWorkbook();

            var ws = wbook.Worksheets.Add("Data");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ws.Cell(startRowIndex + i, j + 1).Value = dt.Rows[i][j];
                    ws.Range(startRowIndex + i, j + 1, startRowIndex + i, j + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
            }

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ws.Cell(1, i + 1).Value = dt.Columns[i].ColumnName;
                ws.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.Green;
                ws.Range(1, i + 1, 1, i + 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                if (i > 2)
                {
                    ws.Range(2, i + 1, stopRowIndex, i + 1).AddConditionalFormat()
                        .WhenNotBetween(VariableGlobal.LimitParametter[i-2].Min, VariableGlobal.LimitParametter[i-2].Max).Fill.SetBackgroundColor(XLColor.Red);
                    //list limit co 16 item, nhung list column cos 18 item. trong do item[0] va item[1] ko co add conditional
                }
            }

            //ws.Range("A1:R1").Style.Border.DiagonalBorder = XLBorderStyleValues.Thin;

            if (Directory.Exists(filePath))
            {
                wbook.SaveAs(Path.Combine(filePath, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_ExportExcel.xlsx"));
            }
            else
            {
                Directory.CreateDirectory(filePath);
                wbook.SaveAs(Path.Combine(filePath, $"{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_ExportExcel.xlsx"));
            }

            
        }
    }
}