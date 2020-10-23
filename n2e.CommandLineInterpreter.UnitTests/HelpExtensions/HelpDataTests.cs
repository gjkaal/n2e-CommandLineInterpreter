namespace n2e.CommandLineInterpreter.UnitTests.HelpExtensions
{
    using n2e.CommandLineInterpreter;
    using n2e.CommandLineInterpreter.HelpExtensions;
    using System.Collections.Generic;
    using Xunit;

    public class HelpDataTests
    {
        private class TestHelpData : HelpData
        {
        }

        private readonly TestHelpData _testClass;

        public HelpDataTests()
        {
            _testClass = new TestHelpData();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new TestHelpData();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetDescription()
        {
            var testValue = "TestValue482708391";
            _testClass.Description = testValue;
            Assert.Equal(testValue, _testClass.Description);
        }

        [Fact]
        public void CanSetAndGetParameters()
        {
            var testValue = new List<CmdArgParam>();
            _testClass.Parameters = testValue;
            Assert.Equal(testValue, _testClass.Parameters);
        }
    }
}