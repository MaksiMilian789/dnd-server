#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DndServer.API/DndServer.API.csproj", "DndServer.API/"]
COPY ["DndServer.Infrastructure/DndServer.Infrastructure.csproj", "DndServer.Infrastructure/"]
COPY ["DndServer.Application/DndServer.Application.csproj", "DndServer.Application/"]
COPY ["DndServer.Domain/DndServer.Domain.csproj", "DndServer.Domain/"]
RUN dotnet restore "./DndServer.API/DndServer.API.csproj"
COPY . .
WORKDIR "/src/DndServer.API"
RUN dotnet build "./DndServer.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DndServer.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DndServer.API.dll"]