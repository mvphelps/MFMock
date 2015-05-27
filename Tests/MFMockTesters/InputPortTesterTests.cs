using System;
using MFMock;
using MFMockTesters;
using MFUnit;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Tests.MFMockTesters
{
    public class InputPortTesterTests
    {
        public void ReadOneSample()
        {
            var t = new InputPortTester();
            IInputPort port = t;

            t.Sample = false;

            Assert.AreEqual(0, t.ReadIndex);
            Assert.AreEqual(false, port.Read());
            Assert.AreEqual(1, t.ReadIndex);

            AssertNoMoreSamples(port);
        }
        public void ReadNoSamples()
        {
            var t = new InputPortTester();
            IInputPort port = t;
            Assert.AreEqual(0, t.ReadIndex);
            AssertNoMoreSamples(port);
        }
        public void ReadMultipleSamples()
        {
            var t = new InputPortTester();
            IInputPort port = t;
            
            t.Samples = new bool[] { true, true, false, false, true };
            
            Assert.AreEqual(true, port.Read());
            Assert.AreEqual(true, port.Read());
            Assert.AreEqual(false, port.Read());
            Assert.AreEqual(3, t.ReadIndex);
            Assert.AreEqual(false, port.Read());
            Assert.AreEqual(true, port.Read());

            AssertNoMoreSamples(port);
        }

        public void ConstructWithSamples()
        {
            var t = new InputPortTester(new bool[] { true, true, false, false, true });
            IInputPort port = t;

            Assert.AreEqual(true, port.Read());
            Assert.AreEqual(true, port.Read());
            Assert.AreEqual(false, port.Read());
            Assert.AreEqual(3, t.ReadIndex);
            Assert.AreEqual(false, port.Read());
            Assert.AreEqual(true, port.Read());
        }
        

        private static void AssertNoMoreSamples(IInputPort port)
        {
            try
            {
                port.Read();
                Assert.Fail("Should throw when number of samples exceeded");
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

    }
}
