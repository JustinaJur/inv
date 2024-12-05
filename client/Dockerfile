# Use the official Node.js image to build the frontend
FROM node:18 AS build

# Set the working directory
WORKDIR /app

COPY client/package*.json ./ 

# Install dependencies
RUN npm install
COPY client/src ./src

# Build the Vue.js app for production
RUN npm run build --prod

# Use the nginx image to serve the static files
FROM nginx:alpine

# Copy the built app to the nginx html directory
COPY --from=build /app/dist /usr/share/nginx/html

# Expose port 80 to the outside world
EXPOSE 80

# Start nginx when the container starts
CMD ["nginx", "-g", "daemon off;"]