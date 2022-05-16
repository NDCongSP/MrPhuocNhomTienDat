using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace ExportTemplate
{
    public class ReadWriteExcel
    {
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

        public DataTable ReadExcelSheet1(string fname, bool firstRowIsHeader,string sheetName)
        {
            List<string> Headers = new List<string>();
            DataTable dt = new DataTable();
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fname, false))
            {
                //Read the first Sheets 
                //Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                //Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
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

        public string GetCellValue(SpreadsheetDocument doc, Cell cell)
        {
            string value = cell.CellValue.InnerText;
            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
            }
            return value;
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
                        if (col == "NhietDoNuocNhomTrongLo" || col == "NhietDoNhomTruocKhuon" || col == "NhietDoNhomTaiMiengLo"
                            || col == "NhietDoNuocGiaiNhietMam" || col == "NhietDoNuocMatGieng" || col == "NhietDoKhongKhiTrongLo" || col == "DuongKinh"
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

        public void ExportTemplate(string filePath, DataTable dt)
        {
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, true))
            {
                WorkbookPart wbp = doc.WorkbookPart;

                WorksheetPart wsp = wbp.WorksheetParts.First();

                Worksheet ws = wsp.Worksheet;
                SheetData sheetData = ws.GetFirstChild<SheetData>();

                char[] refrence = "ABC".ToCharArray();

                foreach (DataRow item in dt.Rows)
                {
                    int skipRowIndex = 2;
                    skipRowIndex += dt.Rows.IndexOf(item);

                    Row row = new Row();
                    for (int i = 0; i < item.ItemArray.Length; i++)
                    {
                        Cell cell = new Cell()
                        {
                            CellValue = new CellValue(item[i].ToString()),
                            CellReference = refrence[i].ToString() + skipRowIndex,
                            DataType = CellValues.Number,
                            
                        };
                        row.Append(cell);
                    }
                    sheetData.Append(row);
                }
                wbp.Workbook.Save();
                //doc.Save();
                doc.SaveAs(@"D:\MyCompany\7.SourceCode\3.Projects\MrPhuocCtySonThinhBD\sourceCode\ExportTemplate/test.xlsx");
                //doc.Close();
            }
        }

        public void ExportTemplate1(string filePath, DataTable dt)
        {
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(filePath, true))
            {
                WorkbookPart wbp = doc.WorkbookPart;

                WorksheetPart wsp = wbp.WorksheetParts.First();

                Worksheet ws = wsp.Worksheet;
                SheetData sheetData = ws.GetFirstChild<SheetData>();


                char[] refrence = "ABC".ToCharArray();

                foreach (DataRow item in dt.Rows)
                {
                    int skipRowIndex = 2;
                    skipRowIndex += dt.Rows.IndexOf(item);

                    Row row = new Row();
                    for (int i = 0; i < item.ItemArray.Length; i++)
                    {
                        Cell cell = new Cell()
                        {
                            CellValue = new CellValue(item[i].ToString()),
                            CellReference = refrence[i].ToString() + skipRowIndex,
                            DataType = CellValues.Number,

                        };
                        row.Append(cell);
                    }
                    sheetData.Append(row);
                }

                

                wbp.Workbook.Save();
                //doc.Save();
                doc.SaveAs(@"D:\MyCompany\7.SourceCode\3.Projects\MrPhuocCtySonThinhBD\sourceCode\ExportTemplate/test.xlsx");
                //doc.Close();
            }
        }

      
    }
}