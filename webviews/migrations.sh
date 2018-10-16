#!/bin/bash
DATE=`date '+%Y%m%d%H%M%S'`

echo "Clean? [y/n]"; read ANSWER
test "$ANSWER" = "y" && rm bin/* -R


echo "Build? [y/n]"; read ANSWER
test "$ANSWER" = "y" && dotnet build

echo "Migration? [y/n]"; read ANSWER
test "$ANSWER" = "y" && dotnet ef migrations add "$DATE"

echo "Database upgrade? [y/n]"; read ANSWER
test "$ANSWER" = "y" && dotnet ef database update

echo "Create runtime? [y/n]"; read ANSWER
test "$ANSWER" = "y" && dotnet publish --runtime win10-x64

echo "Commit? [y/n]"; read ANSWER
test "$ANSWER" = "y" && git add .; git commit "$DATE"