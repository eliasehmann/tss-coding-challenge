#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/TSSCodingChallenge.IntervalMerge/TSSCodingChallenge.IntervalMerge.csproj", "src/TSSCodingChallenge.IntervalMerge/"]
COPY ["tests/TSSCodingChallenge.IntervalMerge.Tests/TSSCodingChallenge.IntervalMerge.Tests.csproj", "tests/TSSCodingChallenge.IntervalMerge.Tests/"]
RUN dotnet restore "src/TSSCodingChallenge.IntervalMerge/TSSCodingChallenge.IntervalMerge.csproj"
RUN dotnet restore "tests/TSSCodingChallenge.IntervalMerge.Tests/TSSCodingChallenge.IntervalMerge.Tests.csproj"
COPY . .
WORKDIR "/src/src/TSSCodingChallenge.IntervalMerge"
RUN dotnet build "TSSCodingChallenge.IntervalMerge.csproj" -c Release -o /app/build
WORKDIR "/src/tests/TSSCodingChallenge.IntervalMerge.Tests"
RUN dotnet test "TSSCodingChallenge.IntervalMerge.Tests.csproj" -c Release
WORKDIR "/src/src/TSSCodingChallenge.IntervalMerge"

FROM build AS publish
RUN dotnet publish "TSSCodingChallenge.IntervalMerge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TSSCodingChallenge.IntervalMerge.dll"]