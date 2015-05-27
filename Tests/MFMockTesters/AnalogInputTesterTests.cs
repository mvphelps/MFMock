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
        public void ReadMultipleRawSamples()
        {
            var t = new AnalogInputTester();
            IAnalogInput port = t;

            t.RawSamples = new int[] { 1, 2, 3, 4, 5 };

            Assert.AreEqual(1, port.ReadRaw());
            Assert.AreEqual(2, port.ReadRaw());
            Assert.AreEqual(3, port.ReadRaw());
            Assert.AreEqual(4, port.ReadRaw());
            Assert.AreEqual(4, t.ReadRawIndex);
            Assert.AreEqual(5, port.ReadRaw());

            AssertNoMoreRawSamples(port);
        }

        public void ConstructWithSamples()
        {
            var t = new AnalogInputTester(new double[] { .097, 1.23, 46.0, -52.3, 5 });
            IAnalogInput port = t;

            Assert.AreEqual((double).097, port.Read());
            Assert.AreEqual((double)1.23, port.Read());
            Assert.AreEqual((double)46.0, port.Read());
            Assert.AreEqual((double)-52.3, port.Read());
            Assert.AreEqual(4, t.ReadIndex);
            Assert.AreEqual((double)5, port.Read());

            AssertNoMoreSamples(port);
        }
        public void ConstructWithRawSamples()
        {
            var t = new AnalogInputTester(new int[] { 1, 2, 3 });
            IAnalogInput port = t;

            Assert.AreEqual(1, port.ReadRaw());
            Assert.AreEqual(2, port.ReadRaw());
            Assert.AreEqual(3, port.ReadRaw());
            Assert.AreEqual(3, t.ReadRawIndex);

            AssertNoMoreRawSamples(port);
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
        private static void AssertNoMoreRawSamples(IAnalogInput port)
        {
            try
            {
                port.ReadRaw();
                Assert.Fail("Should throw when number of raw samples exceeded");
            }
            catch (IndexOutOfRangeException)
            {
            }
        }
    }
}
