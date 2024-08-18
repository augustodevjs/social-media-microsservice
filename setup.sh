#!/bin/bash

# Define colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
NC='\033[0m' # No Color

# Start docker-compose
echo -e "${GREEN}Starting docker-compose...${NC}"
docker-compose up -d

# Define base path
BASE_PATH=$(pwd)

# Add and apply migrations for SocialMedia.Users
echo -e "${GREEN}Adding and applying migrations for SocialMedia.Users...${NC}"
cd "$BASE_PATH/SocialMedia.Users/src/SocialMedia.Users.Infrastructure"
dotnet ef migrations add migration-initial-setup -s ../SocialMedia.Users.API -o ./Persistance/Migrations
dotnet ef database update -s ../SocialMedia.Users.API
cd "$BASE_PATH"

# Add and apply migrations for SocialMedia.Posts
echo -e "${GREEN}Adding and applying migrations for SocialMedia.Posts...${NC}"
cd "$BASE_PATH/SocialMedia.Posts/src/SocialMedia.Posts.Infrastructure"
dotnet ef migrations add migration-initial-setup -s ../SocialMedia.Posts.API -o ./Persistance/Migrations
dotnet ef database update -s ../SocialMedia.Posts.API
cd "$BASE_PATH"

# Add and apply migrations for SocialMedia.NewsFeed
echo -e "${GREEN}Adding and applying migrations for SocialMedia.NewsFeed...${NC}"
cd "$BASE_PATH/SocialMedia.NewsFeed/src/SocialMedia.NewsFeed.Infrastructure"
dotnet ef migrations add migration-initial-setup -s ../SocialMedia.NewsFeed.API -o ./Persistance/Migrations
dotnet ef database update -s ../SocialMedia.NewsFeed.API

echo -e "${GREEN}Setup completed successfully.${NC}"
