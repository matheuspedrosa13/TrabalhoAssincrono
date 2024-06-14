FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

COPY . ./
RUN dotnet restore TrabalhoDaniel.sln
RUN dotnet publish TrabalhoDaniel.sln -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .

EXPOSE 5000
ENTRYPOINT ["dotnet", "TrabalhoDaniel.dll"]
