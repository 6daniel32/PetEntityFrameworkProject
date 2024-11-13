#!/bin/bash

# compile the application
docker start compiler

# await until the compilation ends
while [ "$(docker inspect -f '{{.State.Running}}' compiler)" = true ];
do
    echo "Compiling...";
    sleep 1;
done

# Check if the runtime is up
if [ "$(docker ps -q -f name=runtime)" ]; then
    echo "Server restarted";
    docker restart runtime;
else
    # If the runtime is not running, start the whole environment
    echo "Server started";
    docker-compose up -d;
fi