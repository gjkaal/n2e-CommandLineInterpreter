using n2e.CommandLineInterpreter.Abstractions;
using n2e.CommandLineInterpreter.HelpExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace n2e.CommandLineInterpreter
{
    /// <summary>
    /// Command Argument Configurator class.
    /// </summary>
    public class CmdArgConfigurator
    {
        private readonly CmdArgConfiguration _config;
        private IStdOut _console;

        // ********************************************************************************
        /// <summary>
        /// Create a new Command Argument Configurator class.
        /// </summary>
        /// <param name="console">The output console</param>
        /// <param name="config">The parameter configuration</param>
        /// <returns>CmdArgConfiguration</returns>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public CmdArgConfigurator(CmdArgConfiguration config, IStdOut console)
        {
            if (config == null) throw new ArgumentNullException(nameof(config), "Configuration is required.");
            _config = config;
            Console = console;
        }

        // ********************************************************************************
        /// <summary>
        /// Create a new Command Argument Configurator class.
        /// </summary>
        /// <param name="config">The parameter configuration</param>
        /// <returns>CmdArgConfiguration</returns>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public CmdArgConfigurator(CmdArgConfiguration config) : this(config, null)
        {
        }

        /// <summary>
        /// Find the set with configured parameters
        /// </summary>
        public IReadOnlyCollection<CmdArgParam> Parameters => _config.Parameters;

        /// <summary>
        /// True if help on extra arguments is to be rendered.
        /// </summary>
        public bool DisplayExtraArguments => _config.ShowHelpOnExtraArguments;

        /// <summary>
        /// True if a custom renderer is used.
        /// </summary>
        public bool HasCustomRenderer => _config.CustomHelp != null;

        /// <summary>
        /// The console used for rendering the help.
        /// </summary>
        public IStdOut Console
        {
            get => _console ?? new StdConsole();
            set => _console = value;
        }

        // ********************************************************************************
        /// <summary>
        /// Add a single parameter to the configuration.
        /// </summary>
        /// <param name="param">Command line parameter.</param>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public void AddParameter(CmdArgParam param)
        {
            if (param == null) throw new ArgumentNullException(nameof(param), "Empty parameters are not allowed");
            _config.Parameters.Add(param);
        }

        // ********************************************************************************
        /// <summary>
        /// Add parameters to the help configuration.
        /// </summary>
        /// <param name="parameters">A list containing parameter information.</param>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public void AddParameters(IEnumerable<CmdArgParam> parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters), "Empty parameter list is not allowed");

            foreach (var param in parameters.Where(p => p != null))
            {
                AddParameter(param);
            }
        }

        // ********************************************************************************
        /// <summary>
        /// Add parameters to the help configuration.
        /// </summary>
        /// <param name="parameters">Any set of parameters.</param>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public void AddParameters(params CmdArgParam[] parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters), "Empty parameter list is not allowed");

            foreach (var param in parameters.Where(p => p != null))
            {
                AddParameter(param);
            }
        }

        // ********************************************************************************
        /// <summary>
        /// Display the default help text.
        /// </summary>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public void UseDefaultHelp()
        {
            _config.Parameters.Add(new CmdArgParam()
            {
                Description = "Shows application help",
                Key = "help",
                Handler = (val) => DisplayHelp()
            });
        }

        // ********************************************************************************
        /// <summary>
        /// Set the header description for help.
        /// </summary>
        /// <param name="description">Any text.</param>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public void UseDescription(string description)
        {
            if (description == null || string.IsNullOrEmpty(description.Trim()))
            {
                throw new ArgumentNullException(nameof(description), "Cannot accept an empty description or a description with only whitespace.");
            }
            _config.Description = description;
        }

        // ********************************************************************************
        /// <summary>
        /// Set the fag to indicate that more help should be displayed.
        /// </summary>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public void ShowHelpOnExtraArguments()
        {
            _config.ShowHelpOnExtraArguments = true;
        }

        // ********************************************************************************
        /// <summary>
        ///Set the custom help rendering method.
        /// </summary>
        /// <param name="helpAction"></param>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public void CustomHelp(Action<IStdOut, HelpData> helpAction)
        {
            _config.CustomHelp = helpAction;
        }

        // ********************************************************************************
        /// <summary>
        /// Show the help text on the console.
        /// </summary>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public void DisplayHelp()
        {
            if (_config.CustomHelp != null)
            {
                try
                {
                    _config.CustomHelp(Console, _config);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Custom help provided in this implementation thrown an exception.");
                    Console.WriteLine("Exception details:");
                    Console.WriteLine(e.ToString());
                    Console.WriteLine("Showing default help instead:");
                    Help.Show(Console, _config);
                }
            }
            else
            {
                Help.Show(Console, _config);
            }
        }
    }
}