using System;
using MFMock;
using MFUnit;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Tests
{
    public class PWMTests
    {
        public void Wrap()
        {
            IPWM p = new PWM(Cpu.PWMChannel.PWM_0, 100, 50, false).Wrap();
            Assert.IsNotNull(p);    

            p.Start();
            p.DutyCycle = 75;
            p.Stop();
        }
    }
}
