# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY Kanaklytics.API.csproj ./
RUN dotnet restore Kanaklytics.API.csproj

# Copy the rest of the source code
COPY . ./
RUN dotnet publish Kanaklytics.API.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port and start the app
EXPOSE 8080
ENTRYPOINT ["dotnet", "Kanaklytics.API.dll"]