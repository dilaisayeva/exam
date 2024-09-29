# 1. Add the base image for .NET SDK to build the project
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# 2. Copy the .csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# 3. Copy the entire project and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# 4. Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port the app will run on
EXPOSE 80
EXPOSE 443

# 5. Define the entry point for the container
ENTRYPOINT ["dotnet", "ExamSystem.dll"]
