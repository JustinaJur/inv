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
COPY ../inv.sln ./ 
#Copy solution file
COPY backend/backend.csproj ./backend/

# Restore the .NET dependencies using the solution file
RUN dotnet restore inv.sln

# Copy the rest of the application files
COPY . ./ 
# Copy all files in the current directory

# Publish the application - specify the backend project file
RUN dotnet publish backend/backend.csproj -c Release -o out

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

# Set the working directory
WORKDIR /app

# Install fonts (e.g., DejaVu fonts)
RUN apt-get update && apt-get install -y \
    fonts-dejavu-core \
    fonts-dejavu-mono \
    fonts-dejavu-extra \
    && rm -rf /var/lib/apt/lists/*

# Copy the published app from the build stage
COPY --from=build /app/out ./  
# Copy the app from build stage

# Expose the port your app runs on
EXPOSE 80

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "backend.dll"]