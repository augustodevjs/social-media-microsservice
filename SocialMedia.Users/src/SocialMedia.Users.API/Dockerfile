FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/SocialMedia.Users.API/SocialMedia.Users.API.csproj", "src/SocialMedia.Users.API/"]
RUN dotnet restore "./src/SocialMedia.Users.API/./SocialMedia.Users.API.csproj"
COPY . .
WORKDIR "/src/src/SocialMedia.Users.API"
RUN dotnet build "./SocialMedia.Users.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SocialMedia.Users.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SocialMedia.Users.API.dll"]