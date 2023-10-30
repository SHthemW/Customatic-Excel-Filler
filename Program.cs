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
        var rst_test = testFun.Execute(testCase);

        ScriptFunction<default_file, string> fileFun = new DefaultEffectFileGetter(script, nameof(default_file));
        var rst_file = fileFun.Execute();

        Console.WriteLine(rst_test + "\n" + rst_file);

        ITableFactory tableFactory = new XlsxTableFactory(LocalPath.TablePath);
        using var table = tableFactory.Create("BulletShooterDef");

        Console.WriteLine(table.Table);

        Console.ReadKey();
    }
}
