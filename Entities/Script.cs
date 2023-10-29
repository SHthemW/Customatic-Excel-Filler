using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CXlF.Entities
{
    public readonly struct Script
    {
        public string FullPath { get; private init; }
        public dynamic Program { get; private init; }

        public Script(string fullPath, dynamic program)
        {
            FullPath = fullPath ?? throw new ArgumentNullException(nameof(fullPath));
            Program = program ?? throw new ArgumentNullException(nameof(program));
        }
    }
}
