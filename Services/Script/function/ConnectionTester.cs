using CXlF.Entities;

namespace CXlF.Services.Scripts
{
    public delegate string Tester(string testMsg);

    public sealed class ConnectionTester : ScriptFunction<Tester, string>
    {
        public ConnectionTester(Script script, string funcName) : base(script, funcName) 
        { 

        }
        public override string Execute(params dynamic[] args)
        {
            return _function.Invoke((string)args[0]);
        }
    }
}
