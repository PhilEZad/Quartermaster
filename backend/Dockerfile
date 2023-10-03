# Use the official image as a parent image
FROM mcr.microsoft.com/dotnet/core/sdk:latest AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./backend/api/*.csproj ./
RUN dotnet restore

# Copy everything else and build the application
COPY ./backend/api/ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:latest AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet"]