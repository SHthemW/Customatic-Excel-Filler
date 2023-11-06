using CXlF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlF.Services.Scripts.function
{
    public delegate Dictionary<string, dynamic> get_next_row(List<Dictionary<string, dynamic>> prevs);

    public sealed class TableNextRowGetter : ScriptFunction<get_next_row, Dictionary<string, dynamic>>
    {
        public TableNextRowGetter(Script script) : base(script)
        {
        }

        public override string ExtFnNm => nameof(get_next_row);
        public override Dictionary<string, dynamic> Execute(params dynamic[] args)
        {
            if (args.Length != 1)
                throw new ArgumentException($"arg num is not match: expect 1, get {args.Length}");

            if (args[0].GetType() != typeof(List<Dictionary<string, dynamic>>))
                throw new ArgumentException($"arg type is not match: " +
                    $"expect {typeof(List<Dictionary<string, dynamic>>)}, " +
                    $"get {args[0].GetType()}");

            Dictionary<string, dynamic> result = _function.Invoke(args[0]);
            return result;
        }
    }
}
