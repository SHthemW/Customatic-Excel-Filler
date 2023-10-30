using CXlF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlF.Services.Scripts
{
    public delegate string default_file();

    public sealed class DefaultEffectFileGetter : ScriptFunction<default_file, string>
    {
        public DefaultEffectFileGetter(Script script, string funcName) : base(script, funcName)
        {
        }
        public override string Execute(params dynamic[] args)
        {
            return _function.Invoke();
        }
    }
}
