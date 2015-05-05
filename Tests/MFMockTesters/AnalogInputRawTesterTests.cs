using System;
using MFMock;
using MFMockTesters;
using MFUnit;
using Microsoft.SPOT;

namespace Tests.MFMockTesters
{
    public class AnalogInputRawTesterTests
    {
        public void ReadOneSample()
        {
            var t = new AnalogInputTester();
            IAnalogInput port = t;

            t.RawSample = 56;

            Assert.AreEqual(0, t.ReadRawIndex);
            Assert.AreEqual(56, port.ReadRaw());
            Assert.AreEqual(1, t.ReadRawIndex);

            AssertNoMoreSamples(port);
        }
        public void ReadNoSamples()
        {
            var t = new AnalogInputTester();
            IAnalogInput port = t;
            Assert.AreEqual(0, t.ReadRawIndex);
            AssertNoMoreSamples(port);
        }
        public void ReadMultipleSamples()
        {
            var t = new AnalogInputTester();
            IAnalogInput port = t;
            
            t.Samples = new double[] { 1, 2, 3, 4, 5 };

            Assert.AreEqual((double)1, port.Read());
            Assert.AreEqual(0, t.ReadRawIndex);
            Assert.AreEqual((double)2, port.Read());
            Assert.AreEqual((double)3, port.Read());
            Assert.AreEqual((double)4, port.Read());
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
