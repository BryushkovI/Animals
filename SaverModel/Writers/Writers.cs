using Aspose.Cells;
using Aspose.Words;
using Aspose.Words.Tables;
using SaverModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaverModel.Writers
{
    internal class DocWriter : IWriter
    {
        public DocWriter(string[,] table)
        {
            Table = table;
        }
        public string[,] Table { get; set; }
        public string Extension => "docx";

        public string FileName { get; set; }

        public void Write(string name)
        {
            FileName = name;
            var doc = new Document();

            var builder = new DocumentBuilder(doc);

            builder.StartTable();
            for (int i = 0; i < Table.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Table.GetUpperBound(1); j++)
                {
                    builder.InsertCell();
                    builder.Write(Table[i,j]);
                }
                builder.EndRow();
            }
            builder.EndTable();
            doc.Save(string.Format("{0}.{1}", FileName, Extension), Aspose.Words.SaveFormat.Docx);
            

        }
    }

    internal class XlsxWriter : IWriter
    {
        public XlsxWriter(string[,] table)
        {
            Table = table;
        }
        public string[,] Table { get; set; }
        public string Extension => "xlsx";

        public string FileName { get; set; }

        public void Write(string name)
        {
            FileName = name;
            Workbook wb = new();
            Worksheet sheet = wb.Worksheets[0];

            Cells cells = sheet.Cells;

            for (int i = 0; i < Table.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Table.GetUpperBound(1); j++)
                {
                    cells[i,j].Value = Table[i,j];
                }
            }

            wb.Save(string.Format("{0}.{1}", FileName, Extension), Aspose.Cells.SaveFormat.Xlsx);
        }
    }

    internal class PdfWriter : IWriter
    {
        public PdfWriter(string[,] table)
        {
            Table = table;
        }
        public string[,] Table { get; set; }
        public string Extension => "pdf";

        public string FileName { get; set; }

        public void Write(string name)
        {
            FileName = name;
            var pdf = new Aspose.Pdf.Document();
            Aspose.Pdf.Page page = pdf.Pages.Add();

            Aspose.Pdf.Table table = new Aspose.Pdf.Table();
            table.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .2f, Aspose.Pdf.Color.Black);
            table.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .2f, Aspose.Pdf.Color.Black);

            for (int i = 0; i < Table.GetUpperBound(0) + 1; i++)
            {
                Aspose.Pdf.Row row =table.Rows.Add();
                for (int j = 0; j < Table.GetUpperBound(1); j++)
                {
                    row.Cells.Add(Table[i, j]);
                }
            }
            page.Paragraphs.Add(table);
            pdf.Save(string.Format("{0}.{1}", FileName, Extension), Aspose.Pdf.SaveFormat.Pdf);
        }
    }
    internal class NullWriter : IWriter
    {
        public string Extension => string.Empty;

        public string FileName { get; set; }
        public string[,] Table { get; set; }

        public void Write(string name)
        {
            
        }
    }
}
