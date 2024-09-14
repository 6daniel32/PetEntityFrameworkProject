#!/bin/sh

# Function to restart the runtime container
restart_runtime() {
    echo "Changes detected in latest-build. Restarting runtime container..."
    docker-compose restart runtime
}

# Monitor the latest-build volume for changes
inotifywait -m -r -e modify,create,delete /app/build |
while read -r directory events filename; do
    restart_runtime
done