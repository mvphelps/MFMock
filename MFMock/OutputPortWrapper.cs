using Microsoft.SPOT.Hardware;

namespace MFMock
{
    internal class OutputPortWrapper:IOutputPort
    {
        private readonly OutputPort mPort;

        public OutputPortWrapper(OutputPort port)
        {
            mPort = port;
        }
        public bool Read()
        {
            return mPort.Read();
        }

        public void Write(bool state)
        {
            mPort.Write(state);
        }
        public void Dispose()
        {
            mPort.Dispose();
        }
    }
}