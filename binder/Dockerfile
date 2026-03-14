FROM mcr.microsoft.com/dotnet/sdk:9.0

# Install Python and Jupyter
RUN apt-get update && apt-get install -y python3 python3-pip python3-venv
RUN python3 -m venv /opt/venv
ENV PATH="/opt/venv/bin:$PATH"
RUN pip install jupyter jupyterlab

# Install dotnet-interactive from the dev feed
RUN dotnet tool install --global Microsoft.dotnet-interactive \
    --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet-tools/nuget/v3/index.json
ENV PATH="$PATH:/root/.dotnet/tools"

# Register C# kernel
RUN dotnet interactive jupyter install

WORKDIR /home/jovyan