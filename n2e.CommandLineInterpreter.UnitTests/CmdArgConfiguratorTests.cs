namespace n2e.CommandLineInterpreter.UnitTests
{
    using Moq;
    using n2e.CommandLineInterpreter;
    using n2e.CommandLineInterpreter.Abstractions;
    using n2e.CommandLineInterpreter.HelpExtensions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class CmdArgConfiguratorTests
    {
        private readonly CmdArgConfigurator _testClass;
        private readonly CmdArgConfiguration _config;
        private readonly IStdOut _console;

        public CmdArgConfiguratorTests()
        {
            _config = new CmdArgConfiguration { OnUnrecognizedArguments = default(Action<List<string>>), ShowHelpOnExtraArguments = true, CustomHelp = default(Action<IStdOut, HelpData>) };
            _console = new Mock<IStdOut>().Object;
            _testClass = new CmdArgConfigurator(_config, _console);
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new CmdArgConfigurator(_config, _console);
            Assert.NotNull(instance);
            instance = new CmdArgConfigurator(_config);
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullConfig()
        {
            Assert.Throws<ArgumentNullException>(() => new CmdArgConfigurator(default(CmdArgConfiguration), new Mock<IStdOut>().Object));
            Assert.Throws<ArgumentNullException>(() => new CmdArgConfigurator(default(CmdArgConfiguration)));
        }

        [Fact]
        public void CanConstructWithNullConsole()
        {
            var instance = new CmdArgConfigurator(
                new CmdArgConfiguration { OnUnrecognizedArguments = default(Action<List<string>>), ShowHelpOnExtraArguments = false, CustomHelp = default(Action<IStdOut, HelpData>) }, default(IStdOut));
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanCallAddParameter()
        {
            var param = new CmdArgParam { Key = "TestValue131303203", Handler = default(Action<string>), Description = "TestValue1017463587" };
            _testClass.AddParameter(param);
            Assert.NotEmpty(_testClass.Parameters);
        }

        [Fact]
        public void CannotCallAddParameterWithNullParam()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.AddParameter(default(CmdArgParam)));
        }

        [Fact]
        public void CanCallAddParametersWithIEnumerableOfCmdArgParam()
        {
            var parameters = new[] {
                new CmdArgParam { Key = "TestValue1331930797", Handler = default(Action<string>), Description = "TestValue547126392" },
                new CmdArgParam { Key = "TestValue505075162", Handler = default(Action<string>), Description = "TestValue1108596722" },
                new CmdArgParam { Key = "TestValue1367724712", Handler = default(Action<string>), Description = "TestValue515907493" } };
            _testClass.AddParameters(parameters);
            Assert.Equal(3, _testClass.Parameters.Count);
        }

        [Fact]
        public void CannotCallAddParametersWithIEnumerableOfCmdArgParamWithNullParameters()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.AddParameters(default(IEnumerable<CmdArgParam>)));
        }

        [Fact]
        public void CanCallAddParametersWithArrayOfCmdArgParam()
        {
            var parameters = new[] {
                new CmdArgParam { Key = "TestValue1361685866", Handler = default(Action<string>), Description = "TestValue166016546" },
                new CmdArgParam { Key = "TestValue1619782207", Handler = default(Action<string>), Description = "TestValue513140543" },
                new CmdArgParam { Key = "TestValue2145392053", Handler = default(Action<string>), Description = "TestValue1787888934" } };
            _testClass.AddParameters(parameters);
            Assert.Equal(3, _testClass.Parameters.Count);
        }

        [Fact]
        public void CannotCallAddParametersWithArrayOfCmdArgParamWithNullParameters()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.AddParameters(default(CmdArgParam[])));
        }

        [Fact]
        public void CanCallUseDefaultHelp()
        {
            var stdOut = new StdOutStringWriter();
            _testClass.Console = stdOut;
            _testClass.UseDefaultHelp();
            _testClass.DisplayHelp();
            var result = stdOut.ToString();
            Assert.NotEmpty(result);
            Assert.Equal("Help:\r\nKey  Description\r\nhelp Shows application help\r\nArguments are parsed as\r\nKey:Value\r\n", result);
        }

        [Fact]
        public void CanCallUseDescription()
        {
            var description = "TestValue255568780";
            var stdOut = new StdOutStringWriter();
            _testClass.Console = stdOut;
            _testClass.UseDescription(description);
            _testClass.DisplayHelp();
            var result = stdOut.ToString();
            Assert.NotEmpty(result);
            Assert.Contains(description, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotCallUseDescriptionWithInvalidDescription(string value)
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.UseDescription(value));
        }

        [Fact]
        public void CanCallShowHelpOnExtraArguments()
        {
            _testClass.ShowHelpOnExtraArguments();
            Assert.True(_testClass.DisplayExtraArguments, "DisplayExtraArguments should be set to true");
        }

        [Fact]
        public void CanCallCustomHelp()
        {
#pragma warning disable RCS1163 // Unused parameter, discard in lambda is in preview.
            Action<IStdOut, HelpData> helpAction = (IStdOut stdOut, HelpData helpData) =>
#pragma warning restore RCS1163 // Unused parameter.
            {
                customHelpCheck = true;
            };
            _testClass.CustomHelp(helpAction);
            _testClass.DisplayHelp();
            Assert.True(customHelpCheck, "Custom renderer not called.");
        }

        private bool customHelpCheck = false;

        [Fact]
        public void CanCallCustomHelpWithNullHelpAction()
        {
            _testClass.CustomHelp((IStdOut i, HelpData a) => { });
            _testClass.CustomHelp(default(Action<IStdOut, HelpData>));
            Assert.True(true, "Custom renderer can be reset.");
            Assert.False(_testClass.HasCustomRenderer);
        }

        [Fact]
        public void CanCallDisplayHelp()
        {
            var stdOut = new StdOutStringWriter();
            _testClass.Console = stdOut;
            _testClass.DisplayHelp();
            var result = stdOut.ToString();
            Assert.NotEmpty(result);
        }

        [Fact]
        public void ConsoleIsInitializedCorrectly()
        {
            Assert.Equal(_console, _testClass.Console);
        }

        [Fact]
        public void CanSetAndGetConsole()
        {
            var testValue = new Mock<IStdOut>().Object;
            _testClass.Console = testValue;
            Assert.Equal(testValue, _testClass.Console);
        }
    }
}