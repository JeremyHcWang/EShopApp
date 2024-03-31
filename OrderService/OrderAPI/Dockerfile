FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["OrderService/OrderAPI/OrderAPI.csproj", "OrderService/OrderAPI/"]
COPY ["OrderService/OrderAPI_Infrastructure/OrderAPI_Infrastructure.csproj", "OrderService/OrderAPI_Infrastructure/"]
COPY ["OrderService/OrderAPI_ApplicationCore/OrderAPI_ApplicationCore.csproj", "OrderService/OrderAPI_ApplicationCore/"]
RUN dotnet restore "OrderService/OrderAPI/OrderAPI.csproj"
COPY . .
WORKDIR "/src/OrderService/OrderAPI"
RUN dotnet build "OrderAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "OrderAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderAPI.dll"]
