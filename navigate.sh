#!/bin/bash

# First parameter will always be the command to execute.
case $1 in

  run)
    echo $1
    ;;

  *)
    echo "Please, specify a valid dotnet command"
    ;;
esac

exit 0;

dotnet_run() {
    # Check if compiler container is up or not to decide if we should start or restart
    # Same with the runtime container
}

# Function to start the watcher container
start_watcher_container() {
    docker-compose --profile watcher up -d watcher
}

# Function to stop the watcher container
stop_watcher_container() {
    docker-compose --profile watcher stop watcher
}

# NOT FINISHED. PRETTY SURE THAT IT DOESN'T WORK
run_on_sdk() {
    # Check if the container is running
    if [ "$(docker ps -q -f name=sdk)" ]; then
        # If the container is running, execute the command inside the container
        docker exec -it sdk dotnet "$@"
    else
        # If the container is not running, start the container and execute the command
        docker-compose run --rm sdk dotnet "$@"
    fi
}

