## SocialMedia.Users

cd ./SocialMedia.Users/src/SocialMedia.Users.Infrastructure 

dotnet ef migrations add initialMigration -s ..\SocialMedia.Users.API\ -o .\Persistance\Migrations

dotnet ef database update -s ..\SocialMedia.Users.API\