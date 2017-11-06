# escape=` 
 
FROM microsoft/aspnet
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop';"]

ADD enablessl.ps1 /windows/temp/enablessl.ps1
RUN powershell.exe -executionpolicy bypass c:\windows\temp\enablessl.ps1

# The final instruction copies the site you published earlier into the container.
COPY ./bin/Release/PublishOutput/ /inetpub/wwwroot

# configure IIS to write a global log file:
RUN Set-WebConfigurationProperty -pspath 'MACHINE/WEBROOT/APPHOST' -filter 'system.applicationHost/log' -name 'centralLogFileMode' -value 'CentralW3C'; `
    Set-WebConfigurationProperty -pspath 'MACHINE/WEBROOT/APPHOST' -filter 'system.applicationHost/log/centralW3CLogFile' -name 'truncateSize' -value 4294967295; `
    Set-WebConfigurationProperty -pspath 'MACHINE/WEBROOT/APPHOST' -filter 'system.applicationHost/log/centralW3CLogFile' -name 'period' -value 'MaxSize'; `
    Set-WebConfigurationProperty -pspath 'MACHINE/WEBROOT/APPHOST' -filter 'system.applicationHost/log/centralW3CLogFile' -name 'directory' -value 'c:\iislog'

EXPOSE 80 443

ENTRYPOINT Start-Service W3SVC; `
		   Invoke-WebRequest http://localhost -UseBasicParsing | Out-Null; `
		   netsh http flush logbuffer | Out-Null; `
		   Get-Content -path 'c:\iislog\W3SVC\u_extend1.log' -Tail 1 -Wait 