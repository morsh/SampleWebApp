# The `FROM` instruction specifies the base image. You are
# extending the `microsoft/aspnet` image.

FROM microsoft/aspnet

ADD enablessl.ps1 /windows/temp/enablessl.ps1
RUN powershell.exe -executionpolicy bypass c:\windows\temp\enablessl.ps1

# The final instruction copies the site you published earlier into the container.
COPY ./bin/Release/PublishOutput/ /inetpub/wwwroot