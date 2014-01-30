@ECHO OFF

set UIProjectServiceRefPath =E:\Projects\FP\trunk\Code\FundingPilotSystem\ServiceReferences
set SVCUTILPATHValue =C:\Program Files (x86)\Microsoft SDKs\Windows\v8.0A\bin\NETFX 4.0 Tools

ECHO Generating MasterDataProviderService.CS
"%SVCUTILPATHValue %\svcutil.exe" /o:"%UIProjectServiceRefPath %\MasterDataProviderService.cs" /reference:"E:\Projects\FP\trunk\Code\FundingPilotSystem.PC\bin\Debug\FundingPilotSystem.Domain.dll" /serializer:Auto /edb /ct:System.Collections.Generic.List`1 /ixt  /namespace:*,FundingPilotSystem.Services.FPMasterValues.MasterDataProviderService http://localhost/FundingPilotSystemServices/FPMasterValues/MasterDataProviderService.svc?wsdl

ECHO Generating AdminService.CS
"%SVCUTILPATHValue %\svcutil.exe" /o:"%UIProjectServiceRefPath %\RegistrationProcessService.cs" /reference:"E:\Projects\FP\trunk\Code\FundingPilotSystem.PC\bin\Debug\FundingPilotSystem.Domain.dll" /serializer:Auto /edb /ct:System.Collections.Generic.List`1 /ixt  /namespace:*,FundingPilotSystem.Services.FPUserProfile.RegistrationService http://localhost/FundingPilotSystemServices/FPUserProfile/RegistrationService.svc?wsdl


set /p delBuild=press any key to exit:
