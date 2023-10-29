using System;
using CXlF.Entities;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace CXlF.Services.Scripts;

public sealed class PythonScriptFactory : FileService, IScriptFactory
{
    protected override string _suffix => ".py";

    public PythonScriptFactory(string filePath) : base(filePath) { }
    Script IScriptFactory.Create(string scriptName)
    {
        return new Script(GetFullPath(scriptName), GetProgram(scriptName));
    }

    private dynamic GetProgram(string scriptName)
    {
        ScriptEngine pyEngine = Python.CreateEngine();
        ScriptScope? scope;
        try
        {
            scope = pyEngine.ExecuteFile(GetFullPath(scriptName));
        }
        catch (SyntaxErrorException e)
        {
            Console.WriteLine(e.Message);
            return null!;
        }
        return scope;
    }
}
