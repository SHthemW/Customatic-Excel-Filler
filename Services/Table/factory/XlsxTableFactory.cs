using CXlF.Entities;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;

namespace CXlF.Services.Table
{
    public sealed class XlsxTableFactory : FileService, ITableFactory
    {  
        protected override string _suffix => ".xlsx";

        public XlsxTableFactory(string filePath) : base(filePath)
        {
        }
        TabFile ITableFactory.Create(string fileName)
        {
            IWorkbook workbook;
            using (var fs = new FileStream(GetFullPath(fileName), FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(fs);
            }
            return new TabFile(GetFullPath(fileName), workbook);
        }
    }
}
