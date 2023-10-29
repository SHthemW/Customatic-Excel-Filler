using System;
using System.Collections.Generic;

namespace CXlF.Services
{
    public abstract class FileService
    {
        protected abstract string _suffix { get; }
        protected readonly string _path = string.Empty;

        public FileService(string filePath)
        {
            _path = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        private FileService() { }
        protected string GetFullPath(string fileName)
        {
            var fullPath = fileName.EndsWith(_suffix)
            ? _path + fileName
            : _path + fileName + _suffix;

            if (!File.Exists(fullPath))
                throw new FileNotFoundException(fullPath);

            return fullPath;
        }
    }
}
