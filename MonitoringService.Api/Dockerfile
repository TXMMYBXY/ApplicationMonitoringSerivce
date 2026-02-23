# =========================
# build stage
# =========================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Копируем csproj, чтобы быстрее делать restore
COPY MonitoringService.Api/MonitoringService.Api.csproj MonitoringService.Api/
COPY MonitoringService.Application/MonitoringService.Application.csproj MonitoringService.Application/
COPY MonitoringService.Infrastructure/MonitoringService.Infrastructure.csproj MonitoringService.Infrastructure/

RUN dotnet restore MonitoringService.Api/MonitoringService.Api.csproj

# Копируем всё backend-решение
COPY . .

WORKDIR /src/MonitoringService.Api

RUN dotnet publish MonitoringService.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

# =========================
# runtime stage
# =========================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MonitoringService.Api.dll"]