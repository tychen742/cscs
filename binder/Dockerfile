FROM mcr.microsoft.com/dotnet/sdk:8.0

# Install Python and Jupyter
RUN apt-get update && apt-get install -y python3 python3-pip
RUN pip3 install jupyter jupyterlab --break-system-packages

# Install dotnet-interactive
RUN dotnet tool install --global Microsoft.dotnet-interactive
ENV PATH="$PATH:/root/.dotnet/tools"

# Register C# kernel
RUN dotnet interactive jupyter install

# Set working directory
WORKDIR /home/jovyan
