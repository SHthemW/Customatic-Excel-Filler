using CXlF.Services.Scripts;
using CXlF.Services.Scripts.function;
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

        var tabNxtRowScript = factory.Create("excel_test.py");

        ScriptFunction<get_next_row, Dictionary<string, dynamic>> nextrowFun = 
            new TableNextRowGetter(tabNxtRowScript);

        var rst_nextRow = nextrowFun.Execute(prevRows);

        foreach (var row in rst_nextRow)
            Console.WriteLine(row);

        Console.ReadKey();
    }
}
