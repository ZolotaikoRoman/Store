FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Common/Common.csproj", "Common/"]
COPY ["Store.Common/Store.Common.csproj", "Store.Common/"]
COPY ["Store.WebApi/Store.WebApi.csproj", "Store.WebApi/"]

RUN dotnet restore "Store.WebApi/Store.WebApi.csproj"

COPY . .

RUN dotnet build "Store.WebApi/Store.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Store.WebApi/Store.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Store.WebApi.dll"]