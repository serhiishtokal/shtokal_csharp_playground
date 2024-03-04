FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SerilogPlayground/SerilogPlayground.csproj", "SerilogPlayground/"]
RUN dotnet restore "SerilogPlayground/SerilogPlayground.csproj"
COPY . .
WORKDIR "/src/SerilogPlayground"
RUN dotnet build "SerilogPlayground.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SerilogPlayground.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SerilogPlayground.dll"]
