namespace n2e.CommandLineInterpreter.UnitTests.HelpExtensions
{
    using n2e.CommandLineInterpreter.HelpExtensions;
    using System;
    using Xunit;
    using Moq;
    using n2e.CommandLineInterpreter.Abstractions;
    using System.Collections.Generic;
    using n2e.CommandLineInterpreter;

    

    public static class HelpTests
    {
        private class HelpDataInstance : HelpData { }

        [Fact]
        public static void CanCallShow()
        {
            var console = new Mock<IStdOut>().Object;
            var data = new HelpDataInstance { Description = "TestValue1175564589", Parameters = new List<CmdArgParam>() };
            console.Show(data);
            Assert.True(false, "Create or modify test");
        }

        [Fact]
        public static void CannotCallShowWithNullConsole()
        {
            Assert.Throws<ArgumentNullException>(() => default(IStdOut).Show(new HelpDataInstance { Description = "TestValue5665716", Parameters = new List<CmdArgParam>() }));
        }

        [Fact]
        public static void CannotCallShowWithNullData()
        {
            Assert.Throws<ArgumentNullException>(() => new Mock<IStdOut>().Object.Show(default(HelpData)));
        }
    }
}