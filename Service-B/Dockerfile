# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .        
RUN dotnet restore       
RUN dotnet publish -c Release -o /app

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app . 
EXPOSE 80          
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "Service-B.dll"]
