#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DeskAPI/DeskAPI.csproj", "DeskAPI/"]
COPY ["DeskBusiness/DeskBusiness.csproj", "DeskBusiness/"]
COPY ["DeskData/DeskData.csproj", "DeskData/"]
COPY ["DeskEntity/DeskEntity.csproj", "DeskEntity/"]
RUN dotnet restore "DeskAPI/DeskAPI.csproj"
COPY . .
WORKDIR "/src/DeskAPI"
RUN dotnet build "DeskAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeskAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeskAPI.dll"]