namespace n2e.CommandLineInterpreter.UnitTests
{
    using n2e.CommandLineInterpreter;
    using System;
    using Xunit;
    using Moq;
    using n2e.CommandLineInterpreter.Abstractions;

    public static class ParserTests
    {
        [Fact]
        public static void CanCallParse()
        {
            var configAction = default(Action<CmdArgConfigurator>);
            var stdOut = new Mock<IStdOut>().Object;
            var result = Parser.Parse(configAction, stdOut);
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public static void CannotCallParseWithNullConfigAction()
        {
            Assert.Throws<ArgumentNullException>(() => Parser.Parse(default(Action<CmdArgConfigurator>), new Mock<IStdOut>().Object));
        }

        [Fact]
        public static void CannotCallParseWithNullStdOut()
        {
            Assert.Throws<ArgumentNullException>(() => Parser.Parse(default(Action<CmdArgConfigurator>), default(IStdOut)));
        }
    }
}