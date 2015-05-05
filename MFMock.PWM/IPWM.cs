using System;

namespace MFMock
{
    public interface IPWM:IDisposable
    {
        //uint Duration { get; set; }
        double DutyCycle { get; set; }
        //uint Period { get; set; }
        //PWM.ScaleFactor Scale { get; set; }

        void Start();
        void Stop();
    }
}