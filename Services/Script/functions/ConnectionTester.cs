using CXlF.Entities;

namespace CXlF.Services.Scripts
{
    public sealed class ConnectionTester : ScriptFunction
    {
        public ConnectionTester(Script script) : base(script) { }
        public override dynamic Execute(params dynamic[] args)
        {
            var result = _script.Program.test(args[0]);
            return result;
        }
    }
}
