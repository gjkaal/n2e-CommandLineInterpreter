using System;
using System.Collections.Generic;

namespace n2e.CommandLineInterpreter.HelpExtensions
{
    /// <summary>
    /// Help information object.
    /// </summary>
    public abstract class HelpData
    {
        /// <summary>Clobal description for the help context.</summary>
        public string Description { get; set; }

        /// <summary>Collection of command line parameters</summary>
        public List<CmdArgParam> Parameters { get; set; }
    }
}