using CXlF.Entities;
using System;
using System.Collections.Generic;

namespace CXlF.Services.Scripts
{
    public abstract class ScriptFunction
    {
        protected readonly Script _script;

        public ScriptFunction(Script script)
        {
            _script = script;
        }
        public abstract dynamic? Execute(params dynamic[] args);

        private ScriptFunction() { }
    }
}
