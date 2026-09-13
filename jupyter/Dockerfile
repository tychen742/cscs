FROM mcr.microsoft.com/dotnet/sdk:8.0

ENV DEBIAN_FRONTEND=noninteractive \
    DOTNET_INTERACTIVE_CLI_TELEMETRY_OPTOUT=1 \
    DOTNET_TOOLS=/opt/dotnet-tools \
    PATH=/opt/dotnet-tools:/opt/venv/bin:${PATH}

RUN apt-get update \
    && apt-get install -y --no-install-recommends python3 python3-venv \
    && rm -rf /var/lib/apt/lists/* \
    && python3 -m venv /opt/venv \
    && /opt/venv/bin/pip install --no-cache-dir jupyter-server \
    && dotnet tool install --tool-path "${DOTNET_TOOLS}" Microsoft.dotnet-interactive

RUN useradd --create-home --shell /bin/bash jovyan

COPY jupyter/jupyter_server_config.py /etc/jupyter/jupyter_server_config.py

RUN mkdir -p /workspace /home/jovyan/.local/share/jupyter \
    && chown -R jovyan:jovyan /workspace /home/jovyan

USER jovyan
WORKDIR /workspace

RUN dotnet interactive jupyter install

EXPOSE 8888

CMD ["jupyter", "server", "--config=/etc/jupyter/jupyter_server_config.py"]
