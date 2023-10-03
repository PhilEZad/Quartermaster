# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY Backend.sln ./
COPY API/API.csproj ./API/
COPY Application/Application.csproj ./Application/
COPY Domain/Domain.csproj ./Domain/
COPY Infrastructure/Infrastructure.csproj ./Infrastructure/
COPY UnitTests/UnitTests.csproj ./UnitTests/

# Restore all projects
RUN dotnet restore

# Copy everything
COPY . ./

ENTRYPOINT []