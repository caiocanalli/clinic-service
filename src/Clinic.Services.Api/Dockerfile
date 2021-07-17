FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY src/Clinic.Services.Api/Clinic.Services.Api.csproj src/Clinic.Services.Api/

RUN dotnet restore src/Clinic.Services.Api/Clinic.Services.Api.csproj

COPY . .

WORKDIR src/Clinic.Services.Api
RUN dotnet build Clinic.Services.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Clinic.Services.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Clinic.Services.Api.dll"]
