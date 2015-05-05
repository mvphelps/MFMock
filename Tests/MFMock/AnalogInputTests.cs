using System;
using MFMock;
using MFUnit;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Tests
{
    public class AnalogInputTests
    {
        public void Wrap()
        {
            IAnalogInput p = new AnalogInput(Cpu.AnalogChannel.ANALOG_0).Wrap();
            Assert.IsNotNull(p);    

            //The default for a real AnalogInput not connected to anything returns 0.
            Assert.AreEqual(0, p.ReadRaw());
            Assert.AreEqual(0.0, p.Read());
        }
    }
}
