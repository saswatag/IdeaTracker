#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ThoughtsAndIdeas/ThoughtsAndIdeas.csproj", "ThoughtsAndIdeas/"]
COPY ["ThoughtsConsole/ThoughtsConsole.csproj", "ThoughtsConsole/"]
COPY ["ThoughtsAndIdeasTests/ThoughtsAndIdeasTests.csproj", "ThoughtsAndIdeasTests/"]

#RUN dotnet restore
RUN dotnet restore "ThoughtsConsole/ThoughtsConsole.csproj"
RUN dotnet restore "ThoughtsAndIdeasTests/ThoughtsAndIdeasTests.csproj"

COPY ["ThoughtsAndIdeas/.", "ThoughtsAndIdeas/"]
COPY ["ThoughtsConsole/.", "ThoughtsConsole/"]
COPY ["ThoughtsAndIdeasTests/.", "ThoughtsAndIdeasTests/"]

# build the console client
WORKDIR /src/ThoughtsConsole
RUN dotnet build "ThoughtsConsole.csproj" -c Release -o /app/build

# build the unit tests
WORKDIR /src/ThoughtsAndIdeasTests
RUN dotnet build "ThoughtsAndIdeasTests.csproj" -c Release -o /app/build

# new build target to run the tests seaprately without building the full image
FROM build AS testrunner
WORKDIR /src/ThoughtsAndIdeasTests
CMD ["dotnet", "test", "--logger:trx"]

# run the unit tests
FROM build AS test
WORKDIR /src/ThoughtsAndIdeasTests
RUN dotnet test "ThoughtsAndIdeasTests.csproj" --logger:trx

FROM build AS publish
WORKDIR /src/ThoughtsConsole
RUN dotnet publish "ThoughtsConsole.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ThoughtsConsole.dll"]