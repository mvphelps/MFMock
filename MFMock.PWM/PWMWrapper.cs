using Microsoft.SPOT.Hardware;

namespace MFMock
{
    public class PWMWrapper : IPWM
    {
        private readonly PWM mPort;

        public PWMWrapper(PWM port)
        {
            mPort = port;
        }
        public void Dispose()
        {
            mPort.Dispose();
        }

        public double DutyCycle
        {
            get { return mPort.DutyCycle; } 
            set { mPort.DutyCycle = value; }
        }

        public void Start()
        {
            mPort.Start();
        }

        public void Stop()
        {
            mPort.Stop();
        }
    }
}