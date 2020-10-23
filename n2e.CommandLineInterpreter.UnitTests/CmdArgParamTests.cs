namespace n2e.CommandLineInterpreter.UnitTests
{
    using n2e.CommandLineInterpreter;
    using Xunit;

    public class CmdArgParamTests
    {
        private readonly CmdArgParam _testClass;

        public CmdArgParamTests()
        {
            _testClass = new CmdArgParam();
        }

        [Fact]
        public void CanConstruct()
        {
            var instance = new CmdArgParam();
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetKey()
        {
            var testValue = "TestValue1731805891";
            _testClass.Key = testValue;
            Assert.Equal(testValue, _testClass.Key);
        }

        [Fact]
        public void CanGetKeys()
        {
            Assert.IsType<string[]>(_testClass.Keys);
            Assert.NotNull(_testClass.Keys);
        }

        [Fact]
        public void CanSetAndGetHandler()
        {
            _testClass.Handler = GetTestValue;
            Assert.Equal(GetTestValue, _testClass.Handler);
        }

        private void GetTestValue(string a)
        {
            _canSetAndGetHandlerCheck = true;
        }

        private bool _canSetAndGetHandlerCheck = false;

        [Fact]
        public void CanSetAndGetDescription()
        {
            var testValue = "TestValue1602118133";
            _testClass.Description = testValue;
            Assert.Equal(testValue, _testClass.Description);
        }
    }
}