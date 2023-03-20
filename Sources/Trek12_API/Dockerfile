#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Trek12_API/Trek12_API.csproj", "Trek12_API/"]
COPY ["Stub/Stub/Stub.csproj", "Stub/Stub/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Trek12_API/Trek12_API.csproj"
COPY . .
WORKDIR "/src/Trek12_API"
RUN dotnet build "Trek12_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Trek12_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Trek12_API.dll"]
