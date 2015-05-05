using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace MFMock
{
    public static class MFMockExtensions
    {
        public static IInputPort Wrap(this InputPort source)
        {
            return new InputPortWrapper(source);
        }

        public static IAnalogInput Wrap(this AnalogInput source)
        {
            return new AnalogInputWrapper(source);
        }

        public static IInterruptPort Wrap(this InterruptPort source)
        {
            return new InterruptPortWrapper(source);
        }

        public static IOutputPort Wrap(this OutputPort source)
        {
            return new OutputPortWrapper(source);
        }
    }
}
