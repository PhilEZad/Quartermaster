# Use the official .NET Core SDK image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

# Set the working directory within the container
WORKDIR /app

# Copy the .sln file and restore dependencies (NuGet packages)
COPY ./Backend.sln .
RUN dotnet restore

# Copy the entire backend directory
COPY . .

# Build the API project
WORKDIR /app/API
RUN dotnet build -c Release -o /app/out

# Run the application from the API project
FROM build AS runtime
WORKDIR /app/out
ENTRYPOINT ["dotnet", "API.dll"]