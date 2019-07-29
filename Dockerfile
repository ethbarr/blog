# Build stage
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

WORKDIR /app

# restore
COPY BlogApi/BlogApi.csproj ./BlogApi/
RUN dotnet restore BlogApi/BlogApi.csproj
COPY test/UnitTests/UnitTests.csproj ./test/UnitTests/
RUN dotnet restore test/UnitTests/UnitTests.csproj

# recursively list files copied over
RUN ls -alR 

# copy src
COPY . .

# test - if tests fail we don't get an image
RUN dotnet test test/UnitTests/UnitTests.csproj

# publish
RUN dotnet publish BlogApi/BlogApi.csproj -o /publish

# runtime stage
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
COPY --from=build-env /publish /publish
WORKDIR /publish
ENTRYPOINT ["dotnet", "BlogApi.dll"]
