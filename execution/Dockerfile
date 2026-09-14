FROM mcr.microsoft.com/dotnet/sdk:8.0

ENV DOTNET_CLI_HOME=/tmp/dotnet \
    DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1 \
    DOTNET_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_CLI_WORKLOAD_UPDATE_NOTIFY_DISABLE=1 \
    DOTNET_NOLOGO=1

WORKDIR /app

COPY execution/execution.csproj execution/
RUN dotnet restore execution/execution.csproj

COPY execution/Program.cs execution/
COPY execution/AuthData.cs execution/
COPY execution/NotebookValidation.cs execution/
COPY execution/NotebookRepository.cs execution/
COPY execution/runner-template runner-template
RUN dotnet restore runner-template/runner-template.csproj \
    && dotnet build runner-template/runner-template.csproj --no-restore \
    && dotnet publish execution/execution.csproj --configuration Release --no-restore --output /app/publish

RUN useradd --create-home --shell /usr/sbin/nologin appuser \
    && mkdir -p /data \
    && chown -R appuser:appuser /app /data

USER appuser
EXPOSE 8080

ENTRYPOINT ["dotnet", "/app/publish/execution.dll"]
