using CXlF.Services.Scripts;
using CXlF.Services.Table;
using CXlF.Utilties.Local;

namespace CXlF;

public sealed class Program
{
    static void Main(string[] _)
    {
        string testCase = "csharp";
        
        IScriptFactory factory = new PythonScriptFactory(LocalPath.ScriptPath);
        var script = factory.Create("test.py");

        ScriptFunction<Tester, string> testFun = new ConnectionTester(script, "test");
        var result = testFun.Execute(testCase);

        Console.WriteLine(result);

        ITableFactory tableFactory = new XlsxTableFactory(LocalPath.TablePath);
        using var table = tableFactory.Create("BulletShooterDef");

        Console.WriteLine(table.Table);

        Console.ReadKey();
    }
}
