namespace n2e.CommandLineInterpreter.UnitTests
{
    using n2e.CommandLineInterpreter;
    using n2e.CommandLineInterpreter.Abstractions;
    using n2e.CommandLineInterpreter.HelpExtensions;
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class CmdArgConfigurationTests
    {
        private readonly CmdArgConfiguration _testClass;

        public CmdArgConfigurationTests()
        {
            _testClass = new CmdArgConfiguration();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new CmdArgConfiguration();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetOnUnrecognizedArguments()
        {
            var testValue = default(Action<List<string>>);
            _testClass.OnUnrecognizedArguments = testValue;
            Assert.Equal(testValue, _testClass.OnUnrecognizedArguments);
        }

        [Fact]
        public void CanSetAndGetShowHelpOnExtraArguments()
        {
            var testValue = false;
            _testClass.ShowHelpOnExtraArguments = testValue;
            Assert.Equal(testValue, _testClass.ShowHelpOnExtraArguments);
        }

        [Fact]
        public void CanSetAndGetCustomHelp()
        {
            var testValue = default(Action<IStdOut, HelpData>);
            _testClass.CustomHelp = testValue;
            Assert.Equal(testValue, _testClass.CustomHelp);
        }
    }
}