# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

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

# Stage 2: Install basic fonts
FROM debian:bullseye AS fonts

# Install some basic fonts and font utilities (no MS fonts)
RUN apt-get update && \
    apt-get install -y \
    fonts-dejavu \
    fonts-liberation \
    fontconfig && \
    apt-get clean && \
    rm -rf /var/lib/apt/lists/* && \
    fc-cache -f -v

# Stage 3: Final image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

# Copy installed fonts
COPY --from=fonts /usr/share/fonts/ /usr/share/fonts/
COPY --from=fonts /etc/fonts/ /etc/fonts/

# Set the working directory
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/out ./

# Expose the port your app runs on
EXPOSE 80

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "backend.dll"]