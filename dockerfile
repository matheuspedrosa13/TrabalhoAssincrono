# Etapa 1: Construção
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar os arquivos do projeto e restaurar as dependências
COPY *.sln .
COPY TrabalhoDaniel/*.csproj ./TrabalhoDaniel/
COPY TrabalhoDaniel.Service/*.csproj ./TrabalhoDaniel.Service/
COPY TrabalhoDaniel.Infra/*.csproj ./TrabalhoDaniel.Infra/
COPY TrabalhoDaniel.Repo/*.csproj ./TrabalhoDaniel.Repo/
RUN dotnet restore

# Copiar todo o código e compilar a aplicação
COPY TrabalhoDaniel/. ./TrabalhoDaniel/
COPY TrabalhoDaniel.Service/. ./TrabalhoDaniel.Service/
COPY TrabalhoDaniel.Infra/. ./TrabalhoDaniel.Infra/
COPY TrabalhoDaniel.Repo/. ./TrabalhoDaniel.Repo/
WORKDIR /app/TrabalhoDaniel
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./

# Definir a porta em que o contêiner será exposto
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "TrabalhoDaniel.dll"]
