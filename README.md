# MFMock
Mocking tools for the .NET Micro Framework

This framework provides the basic objects necessary to mock out actual hardware pins in your unit tests. This allows you to test that a particular input produces the desired output. It's just like mocking out a database or other object with a mock framework. This prevents you from having to do live testing with real hardware. For example, if you built an hydraulic powered exoskeleton with the Micro Framework, you wouldn't want to be the first user to find out your code defect crushes the operator. This won't really help your testing effort, as you'll run out of testers.

Currently there is support for AnalogInput, InputPort, InterruptPort, OutputPort and PWM. This covers the Microsoft.SPOT.Hardware classes only, and not the parallel objects in Gadgeteer. 

# Usage in Main Project
To get started, reference the MFMock assembly in your main assembly. Where you create actual IO objects, call the .Wrap() extension method. This will put your port into a wrapper object that supports an interface. Update your code references to use the interface type instead, and your main code is ready to go.

For example, change this:  
```csharp
AnalogInput a = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);
```

To this:  
```csharp
using MFMock;  
IAnalogInput a = new AnalogInput(Cpu.AnalogChannel.ANALOG_0).Wrap();
```

# Usage in Test Project
Set up a unit test project (I use MFUnit). Reference MFMockTesters from Nuget. It contains the mock objects you'll use for testing. Create the corresponding mock object for your unit under test. If it is an input type, it will allow you to set one or more data samples you'd like it to supply. If it is an output type, it will record changes and make them available. 

Example:  
```csharp
var i = new InputPortTester();  
//Setup the input values
i.Samples = new bool[] { true, true, false, false, true };  
  
var o = new OutputPortTester();  
  
var t = new YourTestObjectHere(i, o);  
//Pretend this method will output the inverse of every input it sees.  
//It calls Read() on the input, inverts the value, and sends it to the output.  
//It would look like o.Write(!i.Read());
t.Foo();  

//Assert the inputs given above produces these output changes.  
Assert.AreEqual(false, o.ChangeLog[0].State);  
Assert.AreEqual(false, o.ChangeLog[1].State);  
Assert.AreEqual(true, o.ChangeLog[2].State);  
Assert.AreEqual(true, o.ChangeLog[3].State);  
Assert.AreEqual(false, o.ChangeLog[4].State);  
```

# Examples
See the Examples folder for projects and more demonstrations. I recommend looking at them in this order:

1. SimpleSwitchTests

2. ThermostatTests

3. TouchLampTests
  

# Nuget Packages
**MFMock** This is the core library. Install it in your main project, and in your tests assembly.

**MFMock.PWM** This is the core library for PWM only. If you are using PWM, install it in your main project, and in your tests assembly. Making this a separate assembly allows you to not reference the Microsoft.SPOT.Hardware.PWM library if you are not using it, therefore keeping your deployed code base smaller. 

**MFMock.Testers** This is the mock library. It contains the mock objects to help you in your testing. Install it only in your test project. It depends on both MFMock and MFMock.PWM, and will bring them in when you add it. You can also not use this library; if you want to create your own mocks, simply implement the interfaces from MFMock or MFMock.PWM as needed.

