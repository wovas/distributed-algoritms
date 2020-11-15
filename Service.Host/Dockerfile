#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001
ENV ASPNETCORE_URLS=http://*:5000;https://*:5001

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Service.Host/Service.Host.csproj", "Service.Host/"]
RUN dotnet restore "Service.Host/Service.Host.csproj"
COPY . .
WORKDIR "/src/Service.Host"
RUN dotnet build "Service.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Service.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.Host.dll"]