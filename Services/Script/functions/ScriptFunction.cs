using CXlF.Entities;
using System;
using System.Collections.Generic;

namespace CXlF.Services.Scripts
{
    public abstract class ScriptFunction<TFunc, TReturn> where TFunc : Delegate
    {
        protected readonly Script _script;
        protected readonly TFunc  _function = default!;

        public ScriptFunction(Script script, string funcName)
        {
            _script   = script;
            _function = ExecuteScriptAndGetFunc(funcName);
        }
        public abstract TReturn Execute(params dynamic[] args);

        private ScriptFunction() { }
        private TFunc ExecuteScriptAndGetFunc(string funcName)
        {
            _script.Source.Execute();
            return _script.Scope.GetVariable<TFunc>(funcName);
        }
    }
}
