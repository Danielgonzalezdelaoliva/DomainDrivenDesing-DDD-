# From solution root:
# docker build -t recepcion --progress=plain --no-cache -f .\Delgado.Ddd.Recepcion.API\Dockerfile .


#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Delgado.Ddd.Recepcion.API/Delgado.Ddd.Recepcion.API.csproj", "Delgado.Ddd.Recepcion.API/"]
COPY ["Compartido/Delgado.Ddd.Recepcion.Compartido.csproj", "Compartido/"]
COPY ["Delgado.Ddd.Recepcion.Infraestructura/Delgado.Ddd.Recepcion.Infraestructura.csproj", "Delgado.Ddd.Recepcion.Infraestructura/"]
COPY ["Delgado.Ddd.Recepcion.Dominio/Delgado.Ddd.Recepcion.Dominio.csproj", "Delgado.Ddd.Recepcion.Dominio/"]
RUN dotnet restore "Delgado.Ddd.Recepcion.API/Delgado.Ddd.Recepcion.API.csproj"
COPY . .
WORKDIR "/src/Delgado.Ddd.Recepcion.API"
RUN dotnet build "Delgado.Ddd.Recepcion.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Delgado.Ddd.Recepcion.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Delgado.Ddd.Recepcion.API.dll"]

