using System;
using CXlF.Entities;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace CXlF.Services.Scripts;

public sealed class PythonScriptFactory : IScriptFactory
{
    private const string SCRIPT_SUFFIX = ".py";

    private readonly string _scriptPath = string.Empty;

    public PythonScriptFactory(string scriptPath)
    {
        _scriptPath = scriptPath ?? throw new ArgumentNullException(nameof(scriptPath));
    }
    Script IScriptFactory.Create(string scriptName)
    {
        return new Script(GetFullPath(scriptName), GetProgram(scriptName));
    }
    
    private PythonScriptFactory() { }
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
    private string GetFullPath(string scriptName)
    {
        var fullPath = scriptName.EndsWith(SCRIPT_SUFFIX)
        ? _scriptPath + scriptName
        : _scriptPath + scriptName + SCRIPT_SUFFIX;

        if (!File.Exists(fullPath))
            throw new FileNotFoundException(fullPath);

        return fullPath;
    }
}
