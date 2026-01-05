# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["APIProject.csproj", "./"]
RUN dotnet restore "APIProject.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src"
RUN dotnet build "APIProject.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "APIProject.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIProject.dll"]

