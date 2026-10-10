# CSCS C# runner. Build context: execution/ (see compose.yml).
FROM mcr.microsoft.com/dotnet/sdk:10.0

ENV DOTNET_CLI_HOME=/tmp/dotnet \
    NUGET_PACKAGES=/app/.nuget/packages \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1 \
    DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_DISABLE=1 \
    DOTNET_NOLOGO=1

WORKDIR /app

COPY runner/runner.csproj runner/
RUN dotnet restore runner/runner.csproj

COPY runner/Program.cs runner/
COPY shared shared
COPY runner-template runner-template
# Restore the template's packages at build time: runs use --no-restore and the
# container has no internet access.
RUN dotnet restore runner-template/runner-template.csproj \
    && dotnet build runner-template/runner-template.csproj --no-restore \
    && dotnet publish runner/runner.csproj --configuration Release --no-restore --output /app/publish \
    && rm -rf /root/.nuget/packages /tmp/*

# A dedicated user whose ID matches no account on the host. /app stays owned by root,
# so student code cannot change the server or the template.
RUN useradd --uid 10001 --user-group --no-create-home --shell /usr/sbin/nologin runner

USER runner
EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/publish/cs-runner.dll"]
