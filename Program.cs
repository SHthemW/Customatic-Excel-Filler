using CXlF.Services.Scripts;
using CXlF.Utilties.Local;

namespace CXlF;

public sealed class Program
{
    static void Main(string[] _)
    {
        string testCase = "csharp";
        
        IScriptFactory factory = new PythonScriptFactory(LocalPath.ScriptPath);
        var script = factory.Create("test.py");

        IScriptFunction testFn = new ConnectionTester(script);
        var result = testFn.Execute(testCase);

        Console.WriteLine(result);
    }
}
