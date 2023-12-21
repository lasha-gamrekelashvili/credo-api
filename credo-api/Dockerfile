FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["credo-api/credo-api.csproj", "credo-api/"]
RUN dotnet restore "credo-api/credo-api.csproj"
COPY . .
WORKDIR "/src/credo-api"
RUN dotnet build "credo-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "credo-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "credo-api.dll"]
