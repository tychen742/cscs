# CSCS account, progress, and browser-authoring API. Student code does not run here;
# see runner/Dockerfile. Build context: repository root (see compose.yml).
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_NOLOGO=1

WORKDIR /src

COPY execution/execution.csproj execution/
RUN dotnet restore execution/execution.csproj

COPY execution/Program.cs execution/
COPY execution/AuthData.cs execution/
COPY execution/NotebookValidation.cs execution/
COPY execution/NotebookRepository.cs execution/
COPY execution/GitRepository.cs execution/
COPY execution/Migrations execution/Migrations
RUN dotnet publish execution/execution.csproj --configuration Release --no-restore --output /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0

# git and ssh are for browser authoring (GitRepository.cs).
RUN apt-get update \
    && apt-get install -y --no-install-recommends git openssh-client \
    && rm -rf /var/lib/apt/lists/*

# UID 1000 matches the owner of the existing cscs-data volume.
RUN groupadd --gid 1000 appuser \
    && useradd --uid 1000 --gid appuser --create-home --shell /usr/sbin/nologin appuser \
    && mkdir -p /data \
    && chown -R appuser:appuser /data

COPY --from=build /app/publish /app/publish

WORKDIR /app
USER appuser
EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/publish/execution.dll"]
