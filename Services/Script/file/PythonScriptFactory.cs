using System;
using CXlF.Entities;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace CXlF.Services.Scripts;

public sealed class PythonScriptFactory : FileService, IScriptFactory
{
    protected override string _suffix => ".py";

    private   readonly ScriptEngine _engine;

    public PythonScriptFactory(string filePath) : base(filePath) 
    {
        _engine = Python.CreateEngine();
    }
    Script IScriptFactory.Create(string scriptName)
    {
        return new Script(GetFullPath(scriptName), GetScope(scriptName), GetSource(scriptName));
    }

    private ScriptScope GetScope(string scriptName)
    {
        ScriptScope? scope;
        try
        {
            scope = _engine.ExecuteFile(GetFullPath(scriptName));
        }
        catch (SyntaxErrorException e)
        {
            Console.WriteLine(e.Message);
            return null!;
        }
        return scope;
    }
    private ScriptSource GetSource(string scriptName)
    {
        return _engine.CreateScriptSourceFromFile(GetFullPath(scriptName));
    }
}
