#!/bin/bash

# First parameter will always be the command to execute.
case $1 in

  run)
    source ./local-infra/scripts/dotnet/run.sh
    ;;

  restore)
    docker exec sdk dotnet restore 
    ;;

  new)
    echo 'WIP' 
    ;;

  watch)
    echo 'WIP' 
    ;;

  user-secrets)
    echo 'WIP' 
    ;;

  add package)
    echo 'WIP' 
    ;;

  ef)
    echo 'WIP' 
    ;;

  *)
    echo "Please, specify a valid dotnet command"
    ;;
esac

exit 0;
