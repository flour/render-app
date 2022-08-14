FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 81
EXPOSE 443
EXPOSE 444

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/RenderApp.Api/RenderApp.Api.csproj", "RenderApp.Api/"]
RUN dotnet restore "src/RenderApp.Api/RenderApp.Api.csproj"
COPY . .
WORKDIR "/src/RenderApp.Api"
RUN dotnet build "RenderApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RenderApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RenderApp.Api.dll"]
