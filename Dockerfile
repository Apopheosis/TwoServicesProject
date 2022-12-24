FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
EXPOSE 80
COPY *.csproj ./
COPY ./Init/init.sql /docker-entrypoint-initdb.d/
RUN dotnet restore "servicetwo.csproj"
COPY . ./
RUN dotnet publish servicetwo.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "servicetwo.dll"]