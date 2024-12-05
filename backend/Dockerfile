# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app
COPY ../inv.sln ./
COPY backend/backend.csproj ./backend/

# Restore the .NET dependencies using the solution file
RUN dotnet restore inv.sln

# Copy the rest of the application files
COPY . ./

# Publish the application - specify the backend project file
RUN dotnet publish backend/backend.csproj -c Release -o out

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Set the working directory
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/out ./

# Expose the port your app runs on
EXPOSE 80

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "Backend.dll"]