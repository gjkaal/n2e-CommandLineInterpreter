namespace n2e.CommandLineInterpreter.Abstractions
{
    /// <summary>
    /// Abstraction for standard output.
    /// </summary>
    public interface IStdOut
    {
        /// <summary>
        /// Write text to the output.
        /// </summary>
        /// <param name="text">Any string.</param>
        void WriteLine(string text);

        /// <summary>
        /// Write text to the output, using a template and replace
        /// the placeholder {0} with the string value of p0.
        /// </summary>
        /// <param name="template">Any string.</param>
        /// <param name="p0">The substitute value.</param>
        void WriteLine(string template, object p0);

        /// <summary>
        /// Write text to the output, using a template and replace
        /// the placeholders with the string value of the parameters.
        /// </summary>
        /// <param name="template">Any string.</param>
        /// <param name="p">Parameters for substitution.</param>
        void WriteLine(string template, params object[] p);
    }
}