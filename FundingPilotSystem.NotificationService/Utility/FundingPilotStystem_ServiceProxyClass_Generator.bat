@ECHO OFF

set UIProjectServiceRefPath =..\..\FundingPilotSystem.NotificationService\ServiceReferences
set SVCUTILPATHValue =C:\Program Files\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools

ECHO "%UIProjectServiceRefPath %\FPConfigurationService.cs"

ECHO Generating FPConfigurationService.CS
"%SVCUTILPATHValue %\svcutil.exe" /o:"%UIProjectServiceRefPath %\FPConfigurationService.cs" /reference:"..\..\FundingPilotSystem.NotificationService\bin\Debug\FundingPilotSystem.VM.dll" /serializer:Auto /edb /ct:System.Collections.Generic.List`1 /ixt  /namespace:*,FundingPilotSystem.Services.FPConfigurationService http://localhost/FundingPilotSystemServices/FPConfig/FPConfigurationService.svc?wsdl


set /p delBuild=press any key to exit:
