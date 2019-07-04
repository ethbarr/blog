FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY BlogApi/*.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY BlogApi/. ./
WORKDIR /app/
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 8000
ENTRYPOINT ["dotnet", "BlogApi.dll"]
