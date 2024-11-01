# Imagem base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProdutoAPI2/ProdutoAPI2.csproj", "ProdutoAPI2/"]
RUN dotnet restore "ProdutoAPI2/ProdutoAPI2.csproj"
COPY . .
WORKDIR "/src/ProdutoAPI2"
RUN dotnet build "ProdutoAPI2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProdutoAPI2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProdutoAPI2.dll"]
