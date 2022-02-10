#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/BookManager.Api/BookManager.Api.csproj", "BookManager.Api/"]
COPY ["src/BookManager.ApplicationLayer/BookManager.ApplicationLayer.csproj", "BookManager.ApplicationLayer/"]
COPY ["src/BookManager.Infrastructure/BookManager.Infrastructure.csproj", "BookManager.Infrastructure/"]
RUN dotnet restore "BookManager.Api/BookManager.Api.csproj"
COPY ./src .
WORKDIR "/src/BookManager.Api"
RUN dotnet build "BookManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookManager.Api.dll"]
