using System;
using Microsoft.SPOT.Hardware;

namespace MFMock
{
    public interface IInterruptPort:IDisposable
    {
        void ClearInterrupt();
        void DisableInterrupt();
        void EnableInterrupt();
        bool Read();

        event NativeEventHandler OnInterrupt;
        
    }
}