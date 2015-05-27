del MFMock*.nupkg /s

cd MFMock
nuget.exe pack MFMock.csproj 


cd..
cd MFMock.PWM
nuget.exe pack MFMock.PWM.csproj -IncludeReferencedProjects

cd..
cd MFMock.Testers
nuget.exe pack MFMock.Testers.csproj -IncludeReferencedProjects


pause