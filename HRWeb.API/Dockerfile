FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HRWeb.API/HRWeb.API.csproj", "HRWeb.API/"]
RUN dotnet restore "HRWeb.API/HRWeb.API.csproj"
COPY . .
WORKDIR "/src/HRWeb.API"
RUN dotnet build "HRWeb.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRWeb.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRWeb.API.dll"]