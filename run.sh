## SocialMedia.Users

cd ./SocialMedia.Users/src/SocialMedia.Users.Infrastructure

dotnet ef migrations add initialMigration -s ..\SocialMedia.Users.API\ -o .\Persistance\Migrations

dotnet ef database update -s ..\SocialMedia.Users.API\

## SocialMedia.Posts

cd ./SocialMedia.Posts/src/SocialMedia.Posts.Infrastructure

dotnet ef migrations add initialMigration -s ..\SocialMedia.Posts.API\ -o .\Persistance\Migrations

dotnet ef database update -s ..\SocialMedia.Posts.API\


## SocialMedia.NewsFeed

cd ./SocialMedia.NewsFeed/src/SocialMedia.NewsFeed.Infrastructure

dotnet ef migrations add initialMigration -s ..\SocialMedia.NewsFeed.API\ -o .\Persistance\Migrations

dotnet ef database update -s ..\SocialMedia.NewsFeed.API\