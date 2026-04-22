FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./

WORKDIR /app/RockPaperScissorsWeb
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/RockPaperScissorsWeb/out .

EXPOSE 10000
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "RockPaperScissorsWeb.dll"]