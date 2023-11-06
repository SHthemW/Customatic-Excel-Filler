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

        ScriptFunction<test, string> testFun = new ConnectionTester(script);
        var rst_test = testFun.Execute(testCase);

        ScriptFunction<default_file, string> fileFun = new DefaultEffectFileGetter(script);
        var rst_file = fileFun.Execute();

        Console.WriteLine(rst_test + "\n" + rst_file);

        ITableFactory tableFactory = new XlsxTableFactory(LocalPath.TablePath);
        using var tableFile = tableFactory.Create("BulletShooterDef");

        TableContentParser tableContent = new(tableFile, "Data");
        var prevRows = tableContent.GetPreviousRows();

        foreach (var row in prevRows)
        {
            foreach (var cell in row)
            {
                Console.Write(cell + " ");
            }
            Console.WriteLine("\n");
        }

        Console.WriteLine(tableFile.Table);

        Console.ReadKey();
    }
}
