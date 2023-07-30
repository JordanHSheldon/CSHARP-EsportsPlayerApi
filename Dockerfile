#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EsportsProfileApi.Web/EsportsProfileWebApi.Web/EsportsProfileWebApi.Web.csproj", "EsportsProfileWebApi.Web/"]
COPY ["EsportsProfileApi.Web/EsportsProfileWebApi.DOMAIN/EsportsProfileWebApi.DOMAIN.csproj", "EsportsProfileWebApi.DOMAIN/"]
COPY ["EsportsProfileApi.Web/EsportsProfileWebApi.CROSSCUTTING/EsportsProfileWebApi.CROSSCUTTING.csproj", "EsportsProfileWebApi.CROSSCUTTING/"]
COPY ["EsportsProfileApi.Web/EsportsProfileWebApi.INFRASTRUCTURE/EsportsProfileWebApi.INFRASTRUCTURE.csproj", "EsportsProfileWebApi.INFRASTRUCTURE/"]
RUN dotnet restore "EsportsProfileWebApi.Web/EsportsProfileWebApi.Web.csproj"
COPY . .
WORKDIR "/src/EsportsProfileWebApi.Web"
RUN dotnet build "EsportsProfileWebApi.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EsportsProfileWebApi.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EsportsProfileWebApi.Web.dll"]
