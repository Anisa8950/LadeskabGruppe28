using NUnit.Framework;
using NSubstitute;
using LadeskabLibrary;

namespace Ladeskab.Unit.Test
{
    [TestFixture]
    public class StationControlUnitTest
    {
        private StationControl _uut;
        private IDisplay _display;
        private IDoor _door;
        private ILogFile _logFile;
        private IRFReader _idSource;
        

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _logFile = Substitute.For<ILogFile>();
            _idSource = Substitute.For<IRFReader>();
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}