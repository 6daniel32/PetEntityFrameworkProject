#!/bin/bash

# Function to start the watcher container
start_watcher_container() {
    docker-compose --profile watcher up -d watcher
}

# Function to stop the watcher container
stop_watcher_container() {
    docker-compose --profile watcher stop watcher
}

# Check if the container is running
if [ "$(docker ps -q -f name=dotnet_web)" ]; then
    # If the container is running, execute the command inside the container
    docker exec -it dotnet_web dotnet "$@"
else
    # If the container is not running, start the container and execute the command
    docker-compose run --rm web dotnet "$@"
fi