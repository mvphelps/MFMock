using Microsoft.SPOT.Hardware;

namespace MFMock
{
    internal class AnalogInputWrapper : IAnalogInput
    {
        private AnalogInput mPort;
        public AnalogInputWrapper(AnalogInput port)
        {
            mPort = port;
        }

        public void Dispose()
        {
            mPort.Dispose();
        }

        public double Read()
        {
            return mPort.Read();
        }
        public int ReadRaw()
        {
            return mPort.ReadRaw();
        }
    }
}