# # Use the official .NET SDK image
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# # Set the working directory
# WORKDIR /app
# COPY ../inv.sln ./
# COPY backend/backend.csproj ./backend/

# # Restore the .NET dependencies using the solution file
# RUN dotnet restore inv.sln

# # Copy the rest of the application files
# COPY . ./

# # Publish the application - specify the backend project file
# RUN dotnet publish backend/backend.csproj -c Release -o out

# # Use the official .NET runtime image to run the app
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# # Set the working directory
# WORKDIR /app

# # Copy the published app from the build stage
# COPY --from=build /app/out ./

# # Expose the port your app runs on
# EXPOSE 80

# # Set the entry point to run the application
# ENTRYPOINT ["dotnet", "backend.dll"]

# Use the official .NET SDK image for building the app


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy solution and project files
COPY ../inv.sln ./
COPY backend/backend.csproj ./backend/

# Restore the .NET dependencies
RUN dotnet restore inv.sln

# Copy the rest of the application files
COPY . ./

# Publish the application - specify the backend project file
RUN dotnet publish backend/backend.csproj -c Release -o /app/out

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Set the working directory
WORKDIR /app

# Install fonts only if necessary (remove if not needed)
RUN apt-get update && \
    apt-get install -y ttf-mscorefonts-installer fonts-dejavu fonts-liberation fontconfig && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Copy the published app from the build stage
COPY --from=build /app/out ./

# Expose the port your app runs on
EXPOSE 80

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "backend.dll"]