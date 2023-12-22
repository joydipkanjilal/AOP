#FROM mcr.microsoft.com/dotnet/sdk
#
## Installing Required Packages
#RUN     wget https://packages.microsoft.com/config/debian/11/packages-microsoft-prod.deb -O packages-microsoft-prod.deb && \
        #dpkg -i packages-microsoft-prod.deb && \
        #apt-get update && \
        #apt-get upgrade -y && \
        #apt-get install -y git curl && \
        #apt-get install tmux -y && \
        #apt-get install -y dotnet-runtime-6.0 && \
        #apt-get install -y aspnetcore-runtime-6.0 && \
        #dotnet dev-certs https --trust
#
## Installing NodeJS
#RUN     curl -fsSL https://deb.nodesource.com/setup_14.x | bash - && \
        #apt-get install -y nodejs
#
#RUN     git clone https://github.com/joydipkanjilal/PostSharp.Exception.Demo

#FROM mcr.microsoft.com/dotnet/sdk:7.0
#WORKDIR /buildoutput
#COPY ./buildoutput .
#ENTRYPOINT ["dotnet", "dotnetapp.dll"]


FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

COPY . .
RUN dotnet restore PostSharp.Exception.Demo.csproj --disable-parallel
RUN dotnet publish PostSharp.Exception.Demo.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

ENTRYPOINT ["dotnet", "PostSharp.Exception.Demo.dll"]