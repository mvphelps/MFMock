del MFMock*.nupkg /s

del MFMock\lib\netmf43 /s /Q
xcopy ..\MFMock\bin\Release\*  MFMock\lib\netmf43 /s 
nuget.exe pack MFMock\MFMock.nuspec 
move MFMock*.nupkg MFMock\

del MFMock.PWM\lib\netmf43 /s /Q
xcopy ..\MFMock.PWM\bin\Release\*  MFMock.PWM\lib\netmf43 /s 
nuget.exe pack MFMock.PWM\MFMock.PWM.nuspec
move MFMock.PWM*.nupkg MFMock.PWM\


del MFMock.Testers\lib\netmf43 /s /Q
xcopy ..\MFMock.Testers\bin\Release\*  MFMock.Testers\lib\netmf43 /s 
nuget.exe pack MFMock.Testers\MFMock.Testers.nuspec
move MFMock.Testers*.nupkg MFMock.Testers\


:end
pause