using CXlF.Entities;
using System;
using System.Collections.Generic;

namespace CXlF.Services.Scripts
{
    public interface IScriptFactory
    {
        Script Create(string fileName);
    }
}
