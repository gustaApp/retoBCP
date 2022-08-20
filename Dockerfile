FROM mcr.microsoft.com/dotnet/sdk:3.1 AS builder

WORKDIR /app

COPY ./ ./

WORKDIR /app/RetoBCP.Infraestructura.API/

RUN dotnet restore

RUN dotnet publish -c release -o ./../build

FROM mcr.microsoft.com/dotnet/aspnet:3.1

WORKDIR /app

COPY --from=builder /app/build/ ./

EXPOSE 80

ENTRYPOINT ["dotnet", "RetoBCP.Infraestructura.API.dll"]