FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY ["API/*.csproj", "./API/"]
RUN dotnet restore

COPY . ./