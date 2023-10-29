using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlF.Services.Scripts
{
    public interface IScriptFunction
    {
        dynamic? Execute(params dynamic[] args);
    }
}
