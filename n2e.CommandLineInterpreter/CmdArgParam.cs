using System;
using System.Collections.Generic;
using System.Linq;
using n2e.CommandLineInterpreter.HelpExtensions;

namespace n2e.CommandLineInterpreter
{
    /// <summary>
    /// A command argument parameter.
    /// </summary>
    public class CmdArgParam
    {
        /// <summary>
        /// The method that handles this command
        /// </summary>
        private Action<string> handler;

        /// <summary>
        /// The key or keys for the command. A key may contain aliases seperated by a pipe character. 
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Return the list of keys.
        /// </summary>
        public string[] Keys
        {
            get
            {
                if (string.IsNullOrEmpty(Key))
                {
                    return new string[]{ };
                }
                return Key.Split('|');
            }
        }

        /// <summary>Set the handler for the parameter</summary>
        public Action<string> Handler
        {
            get
            {
                if (handler != null)
                {
                    return handler;
                }
                else
                {
                    return (val) => { };
                }
            }
            set
            {
                handler = value;
            }
        }


        /// <summary>Description for this parameter.</summary>
        public string Description { get; set; }
    }
}
