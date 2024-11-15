#!/bin/bash

# Check if the runtime is up
if [ "$(docker ps -q -f name=runtime)" ]; then
    # Compile the application
    docker start compiler > /dev/null;

    # Await until the compilation ends
    while [ "$(docker inspect -f '{{.State.Running}}' compiler)" = true ];
    do
        echo "Compiling...";
        sleep 1;
    done
    
    # Redeploy the app with the new version of the binary
    echo $'\nRestarting server...';
    docker restart runtime  > /dev/null;
    echo $'Server restarted';
    exit 0;
fi

# Build the containers if they do not exist.
if [ ! "$(docker ps -q -a -f name=runtime)" ]; then
    echo $'Building server...\n';
    docker compose build;
    echo $'\nServer successfully built\n';
fi

# The runtime container was not running, start 
# the whole environment.
echo $'Starting server...\n';
docker compose up -d;
echo $'\nServer started';
exit 0;