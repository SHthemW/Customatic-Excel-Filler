using CXlF.Entities;

namespace CXlF.Services.Scripts
{
    /// <summary>
    /// executable function from script to csharp.
    /// </summary>
    /// <typeparam name="TExtFn"> type of external func. must be assigned as a <see langword="delegate"/>.</typeparam>
    /// <typeparam name="TReturn">return type of this func</typeparam>
    public abstract class ScriptFunction<TExtFn, TReturn> where TExtFn : Delegate
    {
        protected readonly Script _script;
        protected readonly TExtFn _function = default!;
        
        public ScriptFunction(Script script)
        {
            _script   = script;
            _function = ExecuteScriptAndGetFunc();
        }
        public abstract TReturn Execute(params dynamic[] args);
        /// <summary>
        /// external function name.
        /// </summary>
        /// <remarks>
        /// usually it should be same with function <see cref="TExtFn"/>.
        /// if not, program <br/> will execute as that name you override
        /// with a warning.
        /// </remarks>
        public abstract string ExtFnNm { get; }

        private ScriptFunction() { } 
        private TExtFn ExecuteScriptAndGetFunc()
        {
            _script.Source.Execute();
            return _script.Scope.GetVariable<TExtFn>(name: ScriptFuncName());

            string ScriptFuncName()
            {
                if (ExtFnNm != typeof(TExtFn).Name)
                    Console.WriteLine("warning: exteral function name not same as its type.");
                return ExtFnNm;
            }
        }
    }
}
