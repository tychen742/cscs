FROM mcr.microsoft.com/dotnet/sdk:8.0

RUN apt-get update && apt-get install -y python3 python3-pip python3-venv
RUN python3 -m venv /opt/venv
ENV PATH="/opt/venv/bin:$PATH"
RUN pip install jupyter jupyterlab

RUN dotnet tool install --global Microsoft.dotnet-interactive --version 1.0.522904
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet interactive jupyter install

WORKDIR /home/jovyan