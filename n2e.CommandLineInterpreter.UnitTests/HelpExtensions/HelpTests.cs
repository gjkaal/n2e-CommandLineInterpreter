namespace n2e.CommandLineInterpreter.UnitTests.HelpExtensions
{
    using Moq;
    using n2e.CommandLineInterpreter;
    using n2e.CommandLineInterpreter.Abstractions;
    using n2e.CommandLineInterpreter.HelpExtensions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public static class HelpTests
    {
        private class HelpDataInstance : HelpData { }

        [Fact]
        public static void CanCallShow()
        {
            var console = new Mock<IStdOut>();
            var data = new HelpDataInstance { Description = "TestValue1175564589", Parameters = new List<CmdArgParam>() };
            console.Object.Show(data);
            console.Verify(m => m.WriteLine(It.IsAny<string>()));
        }

        [Fact]
        public static void CanCallShowWithNullConsole()
        {
            default(IStdOut).Show(new HelpDataInstance { Description = "TestValue5665716", Parameters = new List<CmdArgParam>() });
            Assert.True(true, "No output if no console is provided.");
        }

        [Fact]
        public static void CannotCallShowWithNullData()
        {
            Assert.Throws<ArgumentNullException>(() => new Mock<IStdOut>().Object.Show(default(HelpData)));
        }
    }
}