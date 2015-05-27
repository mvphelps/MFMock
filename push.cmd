cd MFMock
nuget.exe push MFMock*.nupkg

cd..
cd MFMock.PWM
nuget.exe push MFMock.PWM*.nupkg

cd..
nuget.exe push MFMock.Testers*.nupkg


pause