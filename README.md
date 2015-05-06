# MFMock
Mocking tools for the .NET Micro Framework

This framework provides the basic objects necessary mock out actual hardware pins in your MFUnit tests. This allows you to test that a particular input produces the desired output. It's just like mocking out a database or other object with a mock framework. This prevents you from having to do live testing with real hardware. For example, if you built an insulin pump with the Micro Framework, you wouldn't want to have to implant it in a patient and hope your code worked the first time. Injuring your tester won't help your testing effort, as you'll run out of testers.

To get started, reference the MFMock assembly in your main assembly. Where you create actual IO objects, call the .Wrap() extension method. This will put your port into a wrapper object that supports an interface. Update your code references to use the interface type instead, and your main code is ready to go.

For example, change this:  
AnalogInput a = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);

To this:  
using MFMock;  
IAnalogInput a = new AnalogInput(Cpu.AnalogChannel.ANALOG_0).Wrap();

To test, setup an MFUnit test project, and target the emulator. Reference MFMock, and MFMockTesters. The Testers assembly contains the Mock object you'll use for testing. Create the corresponding mock object. If it is an input type, it will allow you to set one or more data samples you'd like it to supply. If it is an output type, it will record changes and make them available. For example:

Example:  
var i = new InputPortTester();  
i.Samples = new bool[] { true, true, false, false, true };  
  
var o = new OutputPortTester();  
  
var t = new YourTestObjectHere(i, o);  
//Pretend this method will output the inverse of every input it sees.  
//It calls Read() on the input, and Write() on the output.  
t.Foo();  
  
Assert.AreEqual(false, o.ChangeLog[0].State);  
Assert.AreEqual(false, o.ChangeLog[1].State);  
Assert.AreEqual(true, o.ChangeLog[2].State);  
Assert.AreEqual(true, o.ChangeLog[3].State);  
Assert.AreEqual(false, o.ChangeLog[4].State);  
  
That is all there is to it. See the example projects for more demonstrations.
  
Currently there is support for AnalogInput, InputPort, InterruptPort, OutputPort and PWM. Also note that PWM is in a separate assembly (MFMock.PWM), to follow the assembly separation used in the Micro Framework. 

Sorry there is no Nuget package for this yet, that is the next thing I plan to work out.
