using CXlF.Entities;
using System;
using System.Collections.Generic;

namespace CXlF.Services.Table
{
    public interface ITableFactory
    {
        TabFile Create(string fileName);
    }
}
