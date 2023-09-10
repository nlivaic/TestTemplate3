#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestTemplate3.WorkerServices/TestTemplate3.WorkerServices.csproj", "src/TestTemplate3.WorkerServices/"]
COPY ["src/TestTemplate3.Core/TestTemplate3.Core.csproj", "src/TestTemplate3.Core/"]
COPY ["src/TestTemplate3.Common/TestTemplate3.Common.csproj", "src/TestTemplate3.Common/"]
RUN dotnet restore "src/TestTemplate3.WorkerServices/TestTemplate3.WorkerServices.csproj"
COPY . .
WORKDIR "/src/src/TestTemplate3.WorkerServices"
RUN dotnet build "TestTemplate3.WorkerServices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestTemplate3.WorkerServices.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ["src/TestTemplate3.WorkerServices/entrypoint.sh", "src/entrypoint.sh"]
COPY ["src/TestTemplate3.WorkerServices/wait-for-it.sh", "src/wait-for-it.sh"]
CMD ["/bin/bash", "src/entrypoint.sh"]
