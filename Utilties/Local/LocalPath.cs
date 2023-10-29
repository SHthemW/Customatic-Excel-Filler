using System;
using System.Collections.Generic;
using System.Configuration;

namespace CXlF.Utilties.Local
{
    public readonly struct LocalPath
    {
        public static string ScriptPath => GetConfig("scriptpath");

        private static string GetConfig(string fieldName)
        {
            return ConfigurationManager.AppSettings[fieldName]
                ?? throw new ConfigurationErrorsException($"config with given name <{fieldName}> cannot found.");
        }
    }
}


