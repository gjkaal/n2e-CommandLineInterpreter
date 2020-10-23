namespace n2e.CommandLineInterpreter.UnitTests
{
    using Moq;
    using n2e.CommandLineInterpreter;
    using n2e.CommandLineInterpreter.Abstractions;
    using System;
    using Xunit;

    public static class ParserTests
    {
        [Fact]
        public static void CanCallParse()
        {
            Action<CmdArgConfigurator> configAction = (CmdArgConfigurator c) =>
            {
                c.UseDescription("Start");
                c.AddParameter(new CmdArgParam
                {
                    Key = "read",
                    Handler = (string s) => { ReadValue = s; }
                });
            };

            var stdOut = new Mock<IStdOut>().Object;
            var result = Parser.ParseArgs(configAction, stdOut, "start:a", "read:yes");
            // no parameter 'start' defined, so expect the entry ti be in result list
            Assert.NotEmpty(result);
            Assert.Single(result);
            // parameter 'read' is defined and should be handled
            Assert.Equal("yes", ReadValue);
        }

        private static string ReadValue = "Init";

        [Fact]
        public static void CannotCallParseWithNullConfigAction()
        {
            Assert.Throws<ArgumentNullException>(() => Parser.ParseArgs(default(Action<CmdArgConfigurator>), new Mock<IStdOut>().Object));
        }

        [Fact]
        public static void CannotCallParseWithNullStdOut()
        {
            Assert.Throws<ArgumentNullException>(() => Parser.ParseArgs(default(Action<CmdArgConfigurator>), default(IStdOut)));
        }
    }
}