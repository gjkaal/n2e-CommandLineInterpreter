using n2e.CommandLineInterpreter.Abstractions;
using System.Text;

namespace n2e.CommandLineInterpreter
{
    /// <summary>
    /// String writer console
    /// </summary>
    public class StdOutStringWriter : IStdOut
    {
        private StringBuilder sb = new StringBuilder();

        public new string ToString() => sb.ToString();

        /// <inheritdoc/>
        public void WriteLine(string text)
        {
            sb.AppendLine(text);
        }

        /// <inheritdoc/>
        public void WriteLine(string template, object p0)
        {
            sb.AppendFormat(template, p0);
            sb.AppendLine();
        }

        /// <inheritdoc/>
        public void WriteLine(string template, params object[] p)
        {
            sb.AppendFormat(template, p);
            sb.AppendLine();
        }
    }
}