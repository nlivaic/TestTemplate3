#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
# Uncomment if you have other certs this services needs to trust.
#COPY nginx/id-local.crt /usr/local/share/ca-certificates/id-local.crt
#RUN update-ca-certificates
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestTemplate3.Api/TestTemplate3.Api.csproj", "src/TestTemplate3.Api/"]
COPY ["src/TestTemplate3.Data/TestTemplate3.Data.csproj", "src/TestTemplate3.Data/"]
COPY ["src/TestTemplate3.Common/TestTemplate3.Common.csproj", "src/TestTemplate3.Common/"]
COPY ["src/TestTemplate3.Core/TestTemplate3.Core.csproj", "src/TestTemplate3.Core/"]
RUN dotnet restore "src/TestTemplate3.Api/TestTemplate3.Api.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate3.Api"
RUN dotnet build "TestTemplate3.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate3.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestTemplate3.Api.dll"]