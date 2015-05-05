using System;
using MFMock;
using Microsoft.SPOT.Hardware;

namespace MFMockTesters
{
    public class InterruptPortTester : InputPortTester, IInterruptPort
    {
        public void ClearInterrupt()
        {
            IsInterruptCleared = true;
        }
        public void DisableInterrupt()
        {
            IsInterruptEnabled = true;
        }

        public void EnableInterrupt()
        {
            IsInterruptEnabled = false;
        }
        public event NativeEventHandler OnInterrupt;

        //Testing helpers below this line.
        /// <summary>
        /// False after FireInterrupt, True after ClearInterrupt.
        /// </summary>
        public bool IsInterruptCleared { get; private set; }
        /// <summary>
        /// True after EnableInterrupts, False after DisableInterrupt.
        /// </summary>
        public bool IsInterruptEnabled { get; private set; }
        

        public void FireInterrupt()
        {
            if (OnInterrupt != null)
            {
                IsInterruptCleared = false;
                OnInterrupt.Invoke(0, (uint) (Read() ? 1 : 0), DateTime.Now);
            }
        }
 

 
    }
}