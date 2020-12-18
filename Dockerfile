FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

RUN pwsh -Command Write-Host


COPY . ./
RUN dotnet publish -c Release -o dist


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/dist .
ENTRYPOINT ["dotnet", "apiEmprestimoJogos.dll"]