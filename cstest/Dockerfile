# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the project files into the container
COPY *.csproj ./

# Restore dependencies
RUN dotnet restore

# Copy the remaining application files
COPY . ./

# Build the application
RUN dotnet publish /app/cstest.csproj -c Release -o /app/out

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

# Copy the build output from the previous stage
COPY --from=build /app/out ./

# Expose the port your application listens on
EXPOSE 5000

# Set the entry point for the application
ENTRYPOINT ["dotnet", "cstest.dll"]
