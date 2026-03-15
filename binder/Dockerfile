FROM mcr.microsoft.com/dotnet/sdk:8.0

# Create non-root user required by mybinder.org
ARG NB_USER=jovyan
ARG NB_UID=1000
ENV NB_USER=${NB_USER} HOME=/home/${NB_USER}
RUN adduser --disabled-password --gecos "Default user" --uid ${NB_UID} ${NB_USER}

# Python + Jupyter stack
RUN apt-get update && apt-get install -y --no-install-recommends python3 python3-pip python3-venv \
    && rm -rf /var/lib/apt/lists/*
RUN python3 -m venv /opt/venv
ENV PATH="/opt/venv/bin:$PATH"
RUN pip install --no-cache-dir jupyter jupyterlab notebook jupyterhub

# Install dotnet-interactive to a shared path (not /root)
ENV DOTNET_TOOLS=/opt/dotnet-tools
RUN dotnet tool install --tool-path ${DOTNET_TOOLS} Microsoft.dotnet-interactive --version 1.0.522904
ENV PATH="${DOTNET_TOOLS}:${PATH}"

# Switch to non-root user, install Jupyter kernel, pre-warm
USER ${NB_USER}
WORKDIR ${HOME}
RUN dotnet interactive jupyter install
RUN dotnet-interactive --help > /dev/null 2>&1 || true