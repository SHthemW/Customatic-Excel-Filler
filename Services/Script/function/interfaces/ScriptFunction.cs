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
        /// usually, the value of this field should be same with the name <br/>
        /// of function <see cref="TExtFn"/>. IF NOT, the program will execute 
        /// with the <br/> name that this field assigned, and throw a warning.
        /// </remarks>
        /// <seealso cref="ExecuteScriptAndGetFunc"/>
        public abstract string ExtFnNm { get; }

        private ScriptFunction() { } 
        private TExtFn ExecuteScriptAndGetFunc()
        {
            _script.Source.Execute();
            return _script.Scope.GetVariable<TExtFn>(name: CheckAndGetExtFnName()) 
                ?? throw new Exception($"function named {CheckAndGetExtFnName()} was not found.");

            string CheckAndGetExtFnName()
            {
                if (ExtFnNm != typeof(TExtFn).Name)
                    Console.WriteLine("warning: exteral function name not same as its type.");
                return ExtFnNm;
            }
        }
    }
}
