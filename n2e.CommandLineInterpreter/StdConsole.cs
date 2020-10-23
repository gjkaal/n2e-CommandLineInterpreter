using n2e.CommandLineInterpreter.Abstractions;
using System;

namespace n2e.CommandLineInterpreter
{
    /// <summary>
    /// Standard console
    /// </summary>
    public class StdConsole : IStdOut
    {

        /// <inheritdoc/>
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        /// <inheritdoc/>
        public void WriteLine(string template, object p0)
        {
            Console.WriteLine(template, p0);
        }

        /// <inheritdoc/>
        public void WriteLine(string template, params object[] p)
        {
            Console.WriteLine(template, p);
        }
    }
}
