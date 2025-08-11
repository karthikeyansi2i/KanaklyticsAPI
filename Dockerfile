# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj, sln, and props files first (for restore caching)
COPY Kanaklytics.API.csproj ./
COPY Kanaklytics.sln ./
COPY Directory.Packages.props ./   # only if you have this
COPY NuGet.Config ./               # only if you have this

# Restore packages from nuget.org
RUN dotnet restore Kanaklytics.sln --no-cache --source https://api.nuget.org/v3/index.json

# Copy the rest of the source
COPY . ./

# Publish
RUN dotnet publish Kanaklytics.API.csproj -c Release -o /app/publish --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Kanaklytics.API.dll"]