using CXlF.Entities;

namespace CXlF.Services.Scripts
{
    public sealed class ConnectionTester : IScriptFunction
    {
        private readonly Script? _script = null;

        public ConnectionTester(Script? script)
        {
            _script = script ?? throw new ArgumentNullException(nameof(script));
        }
        dynamic? IScriptFunction.Execute(params dynamic[] args)
        {
            var result = _script!.Value.Program.test(args[0]);
            return result;
        }   
    }
}
