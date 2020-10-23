using n2e.CommandLineInterpreter.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace n2e.CommandLineInterpreter
{
    /// <summary>
    /// Helper class for parsing the command line parameters
    /// </summary>
    public static class Parser
    {
        // ********************************************************************************
        /// <summary>
        /// Parse and handle the command line arguments.
        /// </summary>
        /// <param name="configAction"></param>
        /// <param name="stdOut"></param>
        /// <returns></returns>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public static List<string> ParseCommandLineArgs(Action<CmdArgConfigurator> configAction, IStdOut stdOut = null)
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 0) args = args.Skip(1).ToArray(); ;
            return ParseArgs(configAction, stdOut, args);
        }

        // ********************************************************************************
        /// <summary>
        /// Parse and handle the arguments.
        /// </summary>
        /// <param name="configAction">The command line parameter configuration.</param>
        /// <param name="stdOut">Output channel (default null)</param>
        /// <param name="args">arguments</param>
        /// <returns>A list with unrecognized command line arguments.</returns>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public static List<string> ParseArgs(Action<CmdArgConfigurator> configAction, IStdOut stdOut = null, params string[] args)
        {
            if (configAction == null) throw new ArgumentNullException(nameof(configAction), "Expected a method for configurating the command arguments.");
            var config = new CmdArgConfiguration();
            var configurator = new CmdArgConfigurator(config);
            try
            {
                configAction(configurator);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Exception thrown in config action passed to CmdArgParser.Parse method. See inner exception for more details", e);
            }

            var extraArgs = new List<string>();
            if (args.Length > 0)
            {
                foreach (var argument in args)
                {
                    var argumentLC = argument.ToLower();
                    var argParsed = false;
                    foreach (var parameter in config.Parameters)
                    {
                        foreach (var key in parameter.Keys)
                        {
                            if (argumentLC.StartsWith(key))
                            {
                                var rightSide = argument.Substring(key.Length);
                                if (string.IsNullOrEmpty(rightSide))
                                {
                                    parameter.Handler(string.Empty);
                                    argParsed = true;
                                }
                                else if (rightSide.StartsWith(":"))
                                {
                                    var value = rightSide.Substring(1);
                                    parameter.Handler(value);
                                    argParsed = true;
                                }
                            }
                        }
                    }
                    if (!argParsed)
                    {
                        extraArgs.Add(argument);
                    }
                }
            }
            if (extraArgs.Count > 0 && config.ShowHelpOnExtraArguments)
            {
                stdOut?.WriteLine("Unrecognized arguments: ");
                foreach (var extraArg in extraArgs)
                {
                    stdOut?.WriteLine("Key: {0}", extraArg);
                }
            }
            return extraArgs;
        }
    }
}