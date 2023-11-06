using CXlF.Entities;
using NPOI.SS.UserModel;
using System;

namespace CXlF.Services.Table
{
    public sealed class TableContentParser
    {
        private readonly TabFile _table;
        private readonly ISheet _sheet;

        public TableContentParser(TabFile table, string sheetName)
        {
            _table = table;
            _sheet = table.Table.GetSheet(sheetName);
        }
        public List<Dictionary<string, dynamic>> GetPreviousRows(int rowIdx = -1)
        {
            List<Dictionary<string, dynamic>> rows = new();
            IRow headerRow = _sheet.GetRow(0);

            int startRow = 1;
            int endRow = rowIdx == -1 ? _sheet.LastRowNum : rowIdx;

            for (int i = startRow; i < endRow; i++)
            {
                IRow row = _sheet.GetRow(i);
                Dictionary<string, dynamic> dict = new();

                for (int j = row.FirstCellNum; j < row.LastCellNum; j++)
                {
                    ICell cell = row.GetCell(j);
                    string header = headerRow.GetCell(j).StringCellValue;

                    if (cell == null)
                        continue;

                    dict[header] = cell.CellType switch
                    {
                        CellType.Numeric => cell.NumericCellValue,
                        CellType.Boolean => cell.BooleanCellValue,
                        _ => cell.StringCellValue,
                    };
                }
                rows.Add(dict);
            }
            return rows;
        }
    }
}
