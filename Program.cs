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

        ScriptFunction testFun = new ConnectionTester(script);
        var result = testFun.Execute(testCase);

        Console.WriteLine(result);
    }
}
