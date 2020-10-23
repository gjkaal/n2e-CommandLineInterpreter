using n2e.CommandLineInterpreter.Abstractions;
using n2e.CommandLineInterpreter.HelpExtensions;
using System;
using System.Collections.Generic;

namespace n2e.CommandLineInterpreter
{
    // --------------------------------------------------------------------------------
    /// <summary>
    /// Configuration for command line iinterpreter.
    /// </summary>
    // --------------------------------------------------------------------------------
    public class CmdArgConfiguration : HelpData
    {
        /// <summary>Handler for unrecognized arguments.</summary>
        public Action<List<string>> OnUnrecognizedArguments { get; set; }

        /// <summary>Flag for extra help.</summary>
        public bool ShowHelpOnExtraArguments { get; set; }

        /// <summary>Use a custom help rendering.</summary>
        public Action<IStdOut, HelpData> CustomHelp { get; set; }

        // ********************************************************************************
        /// <summary>
        /// Initialize a new CmdArgConfiguration class with defailt parameters.
        /// </summary>
        /// <returns><a new CmdArgConfiguration/returns>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public CmdArgConfiguration()
        {
            Parameters = new List<CmdArgParam>();
            OnUnrecognizedArguments = (list) => { };
            ShowHelpOnExtraArguments = false;
        }
    }
}