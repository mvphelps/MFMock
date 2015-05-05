using Microsoft.SPOT.Hardware;

namespace MFMock
{
    internal class InterruptPortWrapper:IInterruptPort
    {
        private readonly InterruptPort mPort;

        public InterruptPortWrapper(InterruptPort port)
        {
            mPort = port;
        }
        public void Dispose()
        {
            mPort.Dispose();
        }

        public void ClearInterrupt()
        {
            mPort.ClearInterrupt();
        }

        public void DisableInterrupt()
        {
            mPort.DisableInterrupt();
        }

        public void EnableInterrupt()
        {
            mPort.EnableInterrupt();
        }

        public bool Read()
        {
            return mPort.Read();
        }
        event NativeEventHandler IInterruptPort.OnInterrupt
        {
            add { mPort.OnInterrupt += value; }
            remove { mPort.OnInterrupt -= value; }
        }
    }
}