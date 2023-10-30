using CXlF.Entities;

namespace CXlF.Services.Scripts
{
    public delegate string test(string testMsg);

    public sealed class ConnectionTester : ScriptFunction<test, string>
    {      
        public ConnectionTester(Script script) : base(script) 
        { 
            
        }
        public override string ExtFnNm => nameof(test);
        public override string Execute(params dynamic[] args)
        {
            return _function.Invoke((string)args[0]);
        }
    }
}
