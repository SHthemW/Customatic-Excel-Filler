using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;

namespace CXlF.Entities
{
    public readonly struct Script
    {
        public string FullPath { get; private init; }
        public ScriptScope Scope { get; private init; }
        public ScriptSource Source { get; private init; }

        public Script(string fullPath, ScriptScope scope, ScriptSource source)
        {
            FullPath = fullPath ?? throw new ArgumentNullException(nameof(fullPath));
            Source = source ?? throw new ArgumentNullException(nameof(source));
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        }
    }
}
