#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Staff/Staff.API/Staff.API.csproj", "Services/Staff/Staff.API/"]
COPY ["Services/Staff/Staff.Application/Staff.Application.csproj", "Services/Staff/Staff.Application/"]
COPY ["Services/Staff/Staff.Domain/Staff.Domain.csproj", "Services/Staff/Staff.Domain/"]
COPY ["Services/Staff/Staff.Infrastructure/Staff.Infrastructure.csproj", "Services/Staff/Staff.Infrastructure/"]
RUN dotnet restore "./Services/Staff/Staff.API/./Staff.API.csproj"
COPY . .
WORKDIR "/src/Services/Staff/Staff.API"
RUN dotnet build "./Staff.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Staff.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Staff.API.dll"]