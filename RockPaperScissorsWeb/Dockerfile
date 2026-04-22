FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY RockPaperScissorsWeb/RockPaperScissorsWeb/RockPaperScissorsWeb.csproj ./RockPaperScissorsWeb/RUN dotnet restore ./RockPaperScissorsWeb/RockPaperScissorsWeb.csproj

COPY . .
WORKDIR /src/RockPaperScissorsWeb
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 10000
ENV ASPNETCORE_URLS=http://+:10000

ENTRYPOINT ["dotnet", "RockPaperScissorsWeb.dll"]