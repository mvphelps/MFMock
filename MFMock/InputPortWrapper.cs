using Microsoft.SPOT.Hardware;

namespace MFMock
{
    internal class InputPortWrapper:IInputPort
    {
        private readonly InputPort mPort;
        
        public InputPortWrapper(InputPort port)
        {
            mPort = port;
        }
        
        public bool Read()
        {
            return mPort.Read();
        }
        
        public void Dispose()
        {
            mPort.Dispose();
        }
    }
}