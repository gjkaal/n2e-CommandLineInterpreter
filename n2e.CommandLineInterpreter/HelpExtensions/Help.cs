using n2e.CommandLineInterpreter.Abstractions;

namespace n2e.CommandLineInterpreter.HelpExtensions
{
    /// <summary>
    /// Extension class for help
    /// </summary>
    public static class Help
    {
        private static string GetSpaces(int number)
        {
            return new string(' ', number);
        }

        // ********************************************************************************
        /// <summary>
        /// Display the help text on the console.
        /// </summary>
        /// <param name="console">Console used for writing.</param>
        /// <param name="data">The help data for rendering.</param>
        /// <created>GJK,23/10/2020</created>
        /// <changed>GJK,23/10/2020</changed>
        // ********************************************************************************
        public static void Show(this IStdOut console, HelpData data)
        {
            int longestKeyLenght = 5;
            foreach (var item in data.Parameters)
            {
                if (item.Key.Length > longestKeyLenght)
                {
                    longestKeyLenght = item.Key.Length + 2;
                }
            }
            console.WriteLine("Help:");
            if (!string.IsNullOrEmpty(data.Description))
            {
                console.WriteLine(data.Description);
            }
            console.WriteLine("Key{0}Description", GetSpaces(longestKeyLenght - 3));
            foreach (var item in data.Parameters)
            {
                console.WriteLine("{0}{1}{2}", item.Key, GetSpaces(longestKeyLenght - item.Key.Length), item.Description);
            }
            console.WriteLine("Arguments are parsed as");
            console.WriteLine("Key:Value");
        }
    }
}