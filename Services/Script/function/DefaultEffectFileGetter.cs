using CXlF.Entities;
using System;
using System.Collections.Generic;

namespace CXlF.Services.Scripts
{
    public delegate string default_file();

    public sealed class DefaultEffectFileGetter : ScriptFunction<default_file, string>
    {
        public DefaultEffectFileGetter(Script script) : base(script)
        {
        }
        public override string ExtFnNm => nameof(default_file);
        public override string Execute(params dynamic[] args)
        {
            return _function.Invoke();
        }
    }
}
