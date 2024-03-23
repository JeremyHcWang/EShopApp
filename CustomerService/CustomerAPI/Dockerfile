FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV EShopDbContextKey="Server=localhost; Database=EShopDB; User Id=sa; Password=Jeremy07014010; TrustServerCertificate=true"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CustomerService/CustomerAPI/CustomerAPI.csproj", "CustomerService/CustomerAPI/"]
COPY ["CustomerService/CustomerAPI_Infrastructure/CustomerAPI_Infrastructure.csproj", "CustomerService/CustomerAPI_Infrastructure/"]
COPY ["CustomerService/CustomerAPI_ApplicationCore/CustomerAPI_ApplicationCore.csproj", "CustomerService/CustomerAPI_ApplicationCore/"]
RUN dotnet restore "CustomerService/CustomerAPI/CustomerAPI.csproj"
COPY . .
WORKDIR "/src/CustomerService/CustomerAPI"
RUN dotnet build "CustomerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CustomerAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerAPI.dll"]
