#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Workorder.Client/Workorder.Client.csproj", "Workorder.Client/"]
RUN dotnet restore "Workorder.Client/Workorder.Client.csproj"
COPY . .
WORKDIR "/src/Workorder.Client"
RUN dotnet build "Workorder.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Workorder.Client.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Workorder.Client.dll"]