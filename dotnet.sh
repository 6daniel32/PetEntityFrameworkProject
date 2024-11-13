#!/bin/bash

# First parameter will always be the command to execute.
case $1 in

  run)
    source ./local-infra/scripts/dotnet/run.sh
    ;;

  *)
    echo "Please, specify a valid dotnet command"
    ;;
esac

exit 0;
