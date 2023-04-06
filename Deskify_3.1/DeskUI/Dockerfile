#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DeskUI/DeskUI.csproj", "DeskUI/"]
COPY ["DeskData/DeskData.csproj", "DeskData/"]
COPY ["DeskEntity/DeskEntity.csproj", "DeskEntity/"]
RUN dotnet restore "DeskUI/DeskUI.csproj"
COPY . .
WORKDIR "/src/DeskUI"
RUN dotnet build "DeskUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeskUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeskUI.dll"]