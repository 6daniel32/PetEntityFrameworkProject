# Start the development environment
navigate up:
	docker-compose up -d

# TODOS: 
# - Give support to all dotnet commands:
# 	https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet#dotnet-commands
# - Be sure to remove the previous build before creating a new one
# - Complex commands (like dotnet watch) should be abstracted to a script call
#   in a "NavigateSrc" directory
# - Old "navigate.sh" for reference:
#	=======================================
#	!/bin/bash

# 	# Function to start the watcher container
#	start_watcher_container() {
#   	docker-compose --profile watcher up -d watcher
#	}

# 	# Function to stop the watcher container
# 	stop_watcher_container() {
#   	docker-compose --profile watcher stop watcher
#	}

# 	# Check if the container is running
# 	if [ "$(docker ps -q -f name=dotnet_web)" ]; then
# 		# If the container is running, execute the command inside the container
#    	docker exec -it dotnet_web dotnet "$@"
#	else
# 		# If the container is not running, start the container and execute the command
#    	docker-compose run --rm web dotnet "$@"
#	fi
#	=======================================

# Capture all dotnet commands and run them in the SDK container
navigate-%:
	docker exec -it sdk dotnet $*