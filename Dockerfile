# Use .NET 8 SDK for build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj first for restore caching
COPY KanaklyticsAPI/Kanaklytics.API.csproj ./KanaklyticsAPI/

# Restore dependencies
RUN dotnet restore ./KanaklyticsAPI/Kanaklytics.API.csproj

# Copy everything and build
COPY . .
RUN dotnet publish ./KanaklyticsAPI/Kanaklytics.API.csproj -c Release -o /app/publish

# Use .NET 8 runtime for final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Kanaklytics.API.dll"]