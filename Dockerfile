#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Tasklist.Web/Tasklist.Web.csproj", "Tasklist.Web/"]
COPY ["Tasklist.Infraestructure/Tasklist.Infraestructure.csproj", "Tasklist.Infraestructure/"]
COPY ["Tasklist.Domain/Tasklist.Domain.csproj", "Tasklist.Domain/"]
COPY ["Tasklist.Core/Tasklist.Core.csproj", "Tasklist.Core/"]
COPY ["Tasklist.Application/Tasklist.Application.csproj", "Tasklist.Application/"]
RUN dotnet restore "Tasklist.Web/Tasklist.Web.csproj"
COPY . .
WORKDIR "/src/Tasklist.Web"
RUN dotnet build "Tasklist.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tasklist.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Tasklist.Web.dll