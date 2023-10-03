#Get the SDK image to build and publish the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app

#Copy the build file to the app directory
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "dotnet.dll"]

#Expose the port for communication
EXPOSE 80