@ECHO OFF

set UIProjectServiceRefPath =..\..\FundingPilotSystem\ServiceReferences
set SVCUTILPATHValue =C:\Program Files\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools

ECHO "%UIProjectServiceRefPath %\MasterDataProviderService.cs"

ECHO Generating MasterDataProviderService.CS
"%SVCUTILPATHValue %\svcutil.exe" /o:"%UIProjectServiceRefPath %\MasterDataProviderService.cs" /reference:"..\..\FundingPilotSystem.Services\bin\FundingPilotSystem.Common.dll" /reference:"..\..\FundingPilotSystem.Services\bin\FundingPilotSystem.VM.dll" /serializer:Auto /edb /ct:System.Collections.Generic.List`1 /ixt  /namespace:*,FundingPilotSystem.Services.MasterDataProviderService http://localhost/FundingPilotSystemServices/FPMasterValues/MasterDataProviderService.svc?wsdl

ECHO Generating RegistrationProcessService.CS
"%SVCUTILPATHValue %\svcutil.exe" /o:"%UIProjectServiceRefPath %\RegistrationProcessService.cs" /reference:"..\..\FundingPilotSystem.Services\bin\FundingPilotSystem.Common.dll" /reference:"..\..\FundingPilotSystem.Services\bin\FundingPilotSystem.VM.dll" /serializer:Auto /edb /ct:System.Collections.Generic.List`1 /ixt  /namespace:*,FundingPilotSystem.Services.RegistrationService http://localhost/FundingPilotSystemServices/FPUserProfile/RegistrationService.svc?wsdl

ECHO Generating FPConfigurationService.CS
"%SVCUTILPATHValue %\svcutil.exe" /o:"%UIProjectServiceRefPath %\FPConfigurationService.cs" /reference:"..\..\FundingPilotSystem.Services\bin\FundingPilotSystem.Common.dll" /reference:"..\..\FundingPilotSystem.Services\bin\FundingPilotSystem.VM.dll" /serializer:Auto /edb /ct:System.Collections.Generic.List`1 /ixt  /namespace:*,FundingPilotSystem.Services.FPConfigurationService http://localhost/FundingPilotSystemServices/FPConfig/FPConfigurationService.svc?wsdl

set /p delBuild=press any key to exit:
