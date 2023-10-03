# Get the SDK image to build and publish the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy the project files
COPY Backend.Api/Backend.Api.csproj ./Backend.Api/
COPY Backend.Application/Backend.Application.csproj ./Backend.Application/
COPY Backend.Domain/Backend.Domain.csproj ./Backend.Domain/
COPY Backend.Infrastructure/Backend.Infrastructure.csproj ./Backend.Infrastructure/

# Restore as distinct layers
RUN dotnet restore Backend.Api/Backend.Api.csproj

# Copy the rest of the application code
COPY . ./

# Build and publish the API project
RUN dotnet publish Backend.Api/Backend.Api.csproj -c Release -o out/api