FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY . ./
RUN dotnet restore SucessoEventos.Web/SucessoEventos.Web.csproj
RUN dotnet publish SucessoEventos.Web/SucessoEventos.Web.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "SucessoEventos.Web.dll"]
