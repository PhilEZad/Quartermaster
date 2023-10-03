# Get the SDK image to build and publish the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy the solution file and restore as distinct layers
COPY Backend.sln ./
RUN dotnet restore

# Copy the entire solution
COPY . ./

# Build and publish the projects
RUN dotnet publish backend/Backend.Api/Backend.Api.csproj -c Release -o out/api
RUN dotnet publish backend/Backend.Application/Backend.Application.csproj -c Release -o out/application
RUN dotnet publish backend/Backend.Domain/Backend.Domain.csproj -c Release -o out/domain
RUN dotnet publish backend/Backend.Infrastructure/Backend.Infrastructure.csproj -c Release -o out/infrastructure

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app

# Copy the published output from each project
COPY --from=build-env /app/out/api /app/api
COPY --from=build-env /app/out/application /app/application
COPY --from=build-env /app/out/domain /app/domain
COPY --from=build-env /app/out/infrastructure /app/infrastructure

# Set the entry point for the API project
WORKDIR /app/api
ENTRYPOINT ["dotnet", "Backend.Api.dll"]

# Expose the port for communication
EXPOSE 80