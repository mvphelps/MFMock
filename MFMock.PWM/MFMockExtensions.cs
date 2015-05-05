using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace MFMock
{
    public static class MFMockExtensions
    {
        public static IPWM Wrap(this PWM source)
        {
            return new PWMWrapper(source);
        }
    }
}
