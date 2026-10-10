# CSCS browser-authoring API (accounts live in Press). Student code does not run here;
# see runner/Dockerfile. Build context: repository root (see compose.yml).
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_NOLOGO=1

WORKDIR /src

COPY execution/execution.csproj execution/
RUN dotnet restore execution/execution.csproj

COPY execution/Program.cs execution/
COPY execution/NotebookValidation.cs execution/
COPY execution/NotebookRepository.cs execution/
COPY execution/GitRepository.cs execution/
COPY execution/shared execution/shared
RUN dotnet publish execution/execution.csproj --configuration Release --no-restore --output /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0

# git and ssh are for browser authoring (GitRepository.cs).
RUN apt-get update \
    && apt-get install -y --no-install-recommends git openssh-client \
    && rm -rf /var/lib/apt/lists/*

# UID 1000 matches the owner of the existing cscs-data volume. The .NET 10 images
# (Ubuntu 24.04) ship an `ubuntu` user with UID/GID 1000, so remove it first.
RUN userdel --remove ubuntu \
    && groupadd --gid 1000 appuser \
    && useradd --uid 1000 --gid appuser --create-home --shell /usr/sbin/nologin appuser \
    && mkdir -p /data \
    && chown -R appuser:appuser /data

COPY --from=build /app/publish /app/publish

WORKDIR /app
USER appuser
EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/publish/execution.dll"]
