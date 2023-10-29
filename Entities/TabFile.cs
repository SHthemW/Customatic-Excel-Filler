using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;

namespace CXlF.Entities
{
    public readonly struct TabFile : IDisposable
    {
        public string FullPath { get; private init; }
        public IWorkbook Table { get; private init; }

        public TabFile(string fullPath, IWorkbook workbook)
        {
            FullPath = fullPath ?? throw new ArgumentNullException(nameof(fullPath));
            Table = workbook ?? throw new ArgumentNullException(nameof(workbook));
        }
        public void Save()
        {
            using var fs = new FileStream(FullPath, FileMode.Create, FileAccess.Write);
            Table.Write(fs);
        }
        public void Dispose()
        {
            Table.Dispose();
        }
    }
}
