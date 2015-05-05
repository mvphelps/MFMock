using System;
using MFMock;
using MFMockTesters;
using MFUnit;
using Microsoft.SPOT;

namespace Tests.MFMockTesters
{
    public class AnalogInputTesterTests
    {
        public void ReadOneSample()
        {
            var t = new AnalogInputTester();
            IAnalogInput port = t;

            t.Sample = 56.123;

            Assert.AreEqual(0, t.ReadIndex);
            Assert.AreEqual(56.123, port.Read());
            Assert.AreEqual(1, t.ReadIndex);

            AssertNoMoreSamples(port);
        }
        public void ReadNoSamples()
        {
            var t = new AnalogInputTester();
            IAnalogInput port = t;
            Assert.AreEqual(0, t.ReadIndex);
            AssertNoMoreSamples(port);
        }
        public void ReadMultipleSamples()
        {
            var t = new AnalogInputTester();
            IAnalogInput port = t;
            
            t.Samples = new double[] { .097, 1.23, 46.0, -52.3, 5 };

            Assert.AreEqual((double).097, port.Read());
            Assert.AreEqual((double)1.23, port.Read());
            Assert.AreEqual((double)46.0, port.Read());
            Assert.AreEqual((double)-52.3, port.Read());
            Assert.AreEqual(4, t.ReadIndex);
            Assert.AreEqual((double)5, port.Read());

            AssertNoMoreSamples(port);
        }

        private static void AssertNoMoreSamples(IAnalogInput port)
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
