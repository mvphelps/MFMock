del MFMock*.nupkg /s

cd MFMock
nuget.exe pack MFMock.csproj 
REM nuget.exe push MFMock*.nupkg

cd..
cd MFMock.PWM
nuget.exe pack MFMock.PWM.csproj -IncludeReferencedProjects
nuget.exe push MFMock.PWM*.nupkg

cd..
cd MFMock.Testers
nuget.exe pack MFMock.Testers.csproj -IncludeReferencedProjects
nuget.exe push MFMock.Testers*.nupkg


pause