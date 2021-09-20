#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Gestao-Composicoes-Autorais-Src/Gestao-Composicoes-Autorais-Src.csproj", "Gestao-Composicoes-Autorais-Src/"]
RUN dotnet restore "Gestao-Composicoes-Autorais-Src/Gestao-Composicoes-Autorais-Src.csproj"
COPY . .
WORKDIR "/src/Gestao-Composicoes-Autorais-Src"
RUN dotnet build "Gestao-Composicoes-Autorais-Src.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gestao-Composicoes-Autorais-Src.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gestao-Composicoes-Autorais-Src.dll"]