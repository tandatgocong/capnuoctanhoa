using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;
using DocumentFormat.OpenXml;

namespace CAPNUOCTANHOA.Forms.GNKDT
{
    class xmlExcel
    {
        public void BuildWorkbook(string fileName, DataTable ds, string nam, string ky, string madma)
        {
            try
            {
                using (SpreadsheetDocument s = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = s.AddWorkbookPart();
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

                    // Create Styles and Insert into Workbook
                    WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                    Stylesheet styles = CreateStylesheet();
                    styles.Save(stylesPart);

                    string relId = workbookPart.GetIdOfPart(worksheetPart);

                    Workbook workbook = new Workbook();
                    FileVersion fileVersion = new FileVersion { ApplicationName = "Microsoft Office Excel" };
                    Worksheet worksheet = new Worksheet();

                    int numCols = ds.Columns.Count;
                    int[] width_column = { 5, 13, 6, 13, 30, 17, 20, 8, 10, 6, 7, 9, 20 };
                    Columns columns = new Columns();
                    for (int col = 0; col <= numCols; col++)
                    {

                        Column c = CreateColumnData((UInt32)col + 1, (UInt32)numCols + 1, width_column[col]);

                        columns.Append(c);
                    }
                    worksheet.Append(columns);


                    SheetData sheetData = new SheetData();
                    UInt32 index_title = 1;
                    Row title = CreateTitle(index_title, nam, ky, madma);
                    sheetData.AppendChild(title);
                    Row headerRow = CreateHeaderRow(2, ds);
                    sheetData.AppendChild(headerRow);

                    UInt32 index = 3;
                    int stt_dr = 1;
                    foreach (DataRow dr in ds.Rows)
                    {
                        Row contentRow = CreateContentRow(index++, dr, stt_dr);
                        sheetData.AppendChild(contentRow);
                        stt_dr++;
                    }

                    worksheet.Append(sheetData);

                    worksheetPart.Worksheet = worksheet;
                    PageMargins pageMargins1 = new PageMargins();
                    pageMargins1.Left = 0.1D;
                    pageMargins1.Right = 0.1D;
                    pageMargins1.Top = 0.5D;
                    pageMargins1.Bottom = 0.5D;
                    pageMargins1.Header = 0.3D;
                    pageMargins1.Footer = 0.3D;
                    worksheetPart.Worksheet.AppendChild(pageMargins1);
                    PageSetup pageSetup = new PageSetup();
                    pageSetup.Orientation = OrientationValues.Landscape;
                    pageSetup.FitToHeight = 1;
                    pageSetup.FitToWidth = 1;

                    pageSetup.PaperSize = 9;
                    pageSetup.Scale = 95;
                    worksheetPart.Worksheet.AppendChild(pageSetup);
                    worksheetPart.Worksheet.Save();
                    Sheets sheets = new Sheets();
                    Sheet sheet = new Sheet { Name = "Sheet1", SheetId = 1, Id = relId };
                    sheets.Append(sheet);
                    workbook.Append(fileVersion);
                    workbook.Append(sheets);
                    s.WorkbookPart.Workbook = workbook;
                    s.WorkbookPart.Workbook.Save();
                    s.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        private Column CreateColumnData(UInt32 startColumnIndex, UInt32 endColumnIndex, double columnWidth)
        {
            Column column;
            column = new Column();
            column.Min = startColumnIndex;
            column.Max = endColumnIndex;
            column.Width = columnWidth;
            column.CustomWidth = true;
            return column;
        }
        private Row CreateTitle(UInt32 index, string nam, string ky, string madma)
        {
            Row r = new Row { RowIndex = index };
            Cell cell = CreateTextCell("D", index, "DANH SÁCH NHỮNG ĐỒNG HỒ NƯỚC TRONG VÙNG DMA " + madma + "  Kỳ " + ky + " Năm " + nam);
            r.Append(cell);
            return r;
        }
        private Row CreateHeaderRow(UInt32 index, DataTable dt)
        {
            Row r = new Row { RowIndex = index };
            Cell cell_stt = CreateTextCell("STT");
            cell_stt.StyleIndex = 10;
            r.Append(cell_stt);
            foreach (DataColumn col in dt.Columns)
            {
                Cell cell = CreateTextCell(col.ColumnName);
                cell.StyleIndex = 10;
                r.Append(cell);
            }
            return r;
        }

        private Row CreateContentRow(UInt32 index, DataRow dr, int stt_dr)
        {
            Row r = new Row { RowIndex = index };
            Cell cell_stt;
            cell_stt = CreateTextCell(stt_dr.ToString());
            r.Append(cell_stt);
            foreach (Object itm in dr.ItemArray)
            {
                Cell cell;

                if (itm.GetType() == Type.GetType("System.Int32"))
                    cell = CreateNumberCell(Convert.ToInt32(itm));
                else if (itm.GetType() == Type.GetType("System.Decimal"))
                    cell = CreateDecimalCell(Convert.ToDecimal(itm));
                else
                    cell = CreateTextCell(itm.ToString());

                r.Append(cell);
            }
            return r;
        }

        private Cell CreateTextCell(string text)
        {
            Cell c = new Cell { DataType = CellValues.InlineString };
            InlineString istring = new InlineString();
            Text t = new Text { Text = text };
            istring.Append(t);
            c.StyleIndex = 8;
            c.Append(istring);
            return c;
        }

        private Cell CreateTextCell(string header, UInt32 index, string text)
        {
            Cell c = new Cell { DataType = CellValues.InlineString, CellReference = header + index };
            InlineString istring = new InlineString();
            Text t = new Text { Text = text };
            istring.Append(t);
            c.StyleIndex = 12;
            c.Append(istring);
            return c;
        }

        private Cell CreateNumberCell(int number)
        {
            Cell c = new Cell();
            CellValue v = new CellValue { Text = number.ToString() };
            c.StyleIndex = 11;
            c.Append(v);
            return c;
        }

        private Cell CreateNumberCell(string header, UInt32 index, int number)
        {
            Cell c = new Cell { CellReference = header + index };
            CellValue v = new CellValue { Text = number.ToString() };
            c.StyleIndex = 8;
            c.Append(v);
            return c;
        }

        private Cell CreateDecimalCell(decimal number)
        {
            Cell c = new Cell();
            CellValue v = new CellValue { Text = number.ToString() };
            c.StyleIndex = 9;
            c.Append(v);
            return c;
        }

        private Cell CreateDecimalCell(string header, UInt32 index, decimal number)
        {
            Cell c = new Cell { CellReference = header + index };
            CellValue v = new CellValue { Text = number.ToString() };
            c.StyleIndex = 9;
            c.Append(v);
            return c;
        }

        private static Stylesheet CreateStylesheet()
        {
            Stylesheet ss = new Stylesheet();

            Fonts fts = new Fonts();
            DocumentFormat.OpenXml.Spreadsheet.Font ft = new DocumentFormat.OpenXml.Spreadsheet.Font();
            FontName ftn = new FontName();
            ftn.Val = StringValue.FromString("Calibri");
            FontSize ftsz = new FontSize();
            ftsz.Val = DoubleValue.FromDouble(10);
            ft.FontName = ftn;
            ft.FontSize = ftsz;
            fts.Append(ft);

            ft = new DocumentFormat.OpenXml.Spreadsheet.Font();
            ftn = new FontName();
            ftn.Val = StringValue.FromString("Calibri");
            ftsz = new FontSize();
            ftsz.Val = DoubleValue.FromDouble(10);
            Bold ftb = new Bold();
            ftb.Val = BooleanValue.FromBoolean(true);
            ft.FontName = ftn;
            ft.FontSize = ftsz;
            ft.Bold = ftb;
            fts.Append(ft);
            // index2
            ft = new DocumentFormat.OpenXml.Spreadsheet.Font();
            ftn = new FontName();
            ftn.Val = StringValue.FromString("Calibri");
            ftsz = new FontSize();
            ftsz.Val = DoubleValue.FromDouble(15);
            Bold ftbk = new Bold();
            ftb.Val = BooleanValue.FromBoolean(true);
            ft.FontName = ftn;
            ft.FontSize = ftsz;
            ft.Bold = ftbk;
            fts.Append(ft);

            fts.Count = UInt32Value.FromUInt32((uint)fts.ChildElements.Count);

            Fills fills = new Fills();
            Fill fill;
            PatternFill patternFill;
            fill = new Fill();
            patternFill = new PatternFill();
            patternFill.PatternType = PatternValues.None;
            fill.PatternFill = patternFill;
            fills.Append(fill);

            fill = new Fill();
            patternFill = new PatternFill();
            patternFill.PatternType = PatternValues.Gray125;
            fill.PatternFill = patternFill;
            fills.Append(fill);

            fill = new Fill();
            patternFill = new PatternFill();
            patternFill.PatternType = PatternValues.Solid;
            patternFill.ForegroundColor = new ForegroundColor();
            patternFill.ForegroundColor.Rgb = HexBinaryValue.FromString("00ddd9c4");
            patternFill.BackgroundColor = new BackgroundColor();
            patternFill.BackgroundColor.Rgb = patternFill.ForegroundColor.Rgb;
            fill.PatternFill = patternFill;
            fills.Append(fill);

            fills.Count = UInt32Value.FromUInt32((uint)fills.ChildElements.Count);

            Borders borders = new Borders();
            Border border = new Border();
            border.LeftBorder = new LeftBorder();
            border.RightBorder = new RightBorder();
            border.TopBorder = new TopBorder();
            border.BottomBorder = new BottomBorder();
            border.DiagonalBorder = new DiagonalBorder();
            borders.Append(border);

            //Boarder Index 1
            border = new Border();
            border.LeftBorder = new LeftBorder();
            border.LeftBorder.Style = BorderStyleValues.Thin;
            border.RightBorder = new RightBorder();
            border.RightBorder.Style = BorderStyleValues.Thin;
            border.TopBorder = new TopBorder();
            border.TopBorder.Style = BorderStyleValues.Thin;
            border.BottomBorder = new BottomBorder();
            border.BottomBorder.Style = BorderStyleValues.Thin;
            border.DiagonalBorder = new DiagonalBorder();
            borders.Append(border);


            //Boarder Index 2
            border = new Border();
            border.LeftBorder = new LeftBorder();
            border.RightBorder = new RightBorder();
            border.TopBorder = new TopBorder();
            border.TopBorder.Style = BorderStyleValues.Thin;
            border.BottomBorder = new BottomBorder();
            border.BottomBorder.Style = BorderStyleValues.Thin;
            border.DiagonalBorder = new DiagonalBorder();
            borders.Append(border);


            borders.Count = UInt32Value.FromUInt32((uint)borders.ChildElements.Count);

            CellStyleFormats csfs = new CellStyleFormats();
            CellFormat cf = new CellFormat();
            cf.NumberFormatId = 0;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 0;
            csfs.Append(cf);
            csfs.Count = UInt32Value.FromUInt32((uint)csfs.ChildElements.Count);

            uint iExcelIndex = 164;
            NumberingFormats nfs = new NumberingFormats();
            CellFormats cfs = new CellFormats();

            cf = new CellFormat();
            cf.NumberFormatId = 0;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 0;
            cf.FormatId = 0;
            cfs.Append(cf);

            NumberingFormat nfDateTime = new NumberingFormat();
            nfDateTime.NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++);
            nfDateTime.FormatCode = StringValue.FromString("dd/mm/yyyy hh:mm:ss");
            nfs.Append(nfDateTime);

            NumberingFormat nf4decimal = new NumberingFormat();
            nf4decimal.NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++);
            nf4decimal.FormatCode = StringValue.FromString("#,##0.0000");
            nfs.Append(nf4decimal);

            // #,##0.00 is also Excel style index 4
            NumberingFormat nf2decimal = new NumberingFormat();
            nf2decimal.NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++);
            nf2decimal.FormatCode = StringValue.FromString("#,##0.00");
            nfs.Append(nf2decimal);

            // @ is also Excel style index 49
            NumberingFormat nfForcedText = new NumberingFormat();
            nfForcedText.NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++);
            nfForcedText.FormatCode = StringValue.FromString("@");
            nfs.Append(nfForcedText);

            NumberingFormat nfInteger = new NumberingFormat();
            nfInteger.NumberFormatId = UInt32Value.FromUInt32(iExcelIndex++);
            nfInteger.FormatCode = StringValue.FromString("#");
            nfs.Append(nfInteger);

            // index 1
            // Format dd/mm/yyyy
            cf = new CellFormat();
            cf.NumberFormatId = 14;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 0;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);


            // index 2
            // Format #,##0.00
            cf = new CellFormat();
            cf.NumberFormatId = 4;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 0;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);

            // index 3
            cf = new CellFormat();
            cf.NumberFormatId = nfDateTime.NumberFormatId;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 0;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);

            // index 4
            cf = new CellFormat();
            cf.NumberFormatId = nf4decimal.NumberFormatId;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 0;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);

            // index 5
            cf = new CellFormat();
            cf.NumberFormatId = nf2decimal.NumberFormatId;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 0;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);

            // index 6
            cf = new CellFormat();
            cf.NumberFormatId = nfForcedText.NumberFormatId;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 0;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);


            // index 7
            // Header text
            cf = new CellFormat();
            cf.NumberFormatId = nfForcedText.NumberFormatId;
            cf.FontId = 1;
            cf.FillId = 0;
            cf.BorderId = 0;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);

            // index 8
            // column text
            cf = new CellFormat();
            cf.NumberFormatId = nfForcedText.NumberFormatId;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 1;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);

            // index 9
            // coloured 2 decimal text
            cf = new CellFormat();
            cf.NumberFormatId = nf2decimal.NumberFormatId;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 1;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);

            // index 10
            // coloured column text
            cf = new CellFormat();
            cf.NumberFormatId = nfForcedText.NumberFormatId;
            cf.FontId = 1;
            cf.FillId = 2;
            cf.BorderId = 1;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);


            // index 11
            // coloured 2 decimal text
            cf = new CellFormat();
            cf.NumberFormatId = nfInteger.NumberFormatId;
            cf.FontId = 0;
            cf.FillId = 0;
            cf.BorderId = 1;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);

            // index 12
            // coloured 2 decimal text
            cf = new CellFormat();
            cf.NumberFormatId = nfInteger.NumberFormatId;
            cf.FontId = 2;
            cf.FillId = 0;
            cf.BorderId = 0;
            cf.FormatId = 0;
            cf.ApplyNumberFormat = BooleanValue.FromBoolean(true);

            cfs.Append(cf);


            nfs.Count = UInt32Value.FromUInt32((uint)nfs.ChildElements.Count);
            cfs.Count = UInt32Value.FromUInt32((uint)cfs.ChildElements.Count);

            ss.Append(nfs);
            ss.Append(fts);
            ss.Append(fills);
            ss.Append(borders);
            ss.Append(csfs);
            ss.Append(cfs);

            CellStyles css = new CellStyles();
            CellStyle cs = new CellStyle();
            cs.Name = "Normal";
            cs.FormatId = 0;
            cs.BuiltinId = 0;
            css.Append(cs);
            css.Count = (uint)css.ChildElements.Count;
            ss.Append(css);

            DifferentialFormats dfs = new DifferentialFormats();
            dfs.Count = 0;
            ss.Append(dfs);

            TableStyles tss = new TableStyles();
            tss.Count = 0;
            tss.DefaultTableStyle = "TableStyleMedium9";
            tss.DefaultPivotStyle = "PivotStyleLight16";
            ss.Append(tss);

            return ss;
        }
    }
}
