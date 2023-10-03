# Use the official Node.js image as the base image
FROM node:latest AS build

# Set the working directory in the container
WORKDIR /app

# Copy package.json and package-lock.json to the working directory
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the built Next.js application to the container
COPY . /app/

# Set the working directory in the container
WORKDIR /app

# Expose the port the application will run on
EXPOSE 3000

# Start the Next.js application
CMD []