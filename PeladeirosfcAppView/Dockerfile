# Build Blazor WASM
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["PeladeirosfcAppView/PeladeirosfcAppView.csproj", "PeladeirosfcAppView/"]
COPY ["PeladeirosfcApp.Shared/PeladeirosfcApp.Shared.csproj", "PeladeirosfcApp.Shared/"]
RUN dotnet restore "PeladeirosfcAppView/PeladeirosfcAppView.csproj"

COPY . .
WORKDIR /src/PeladeirosfcAppView
RUN dotnet publish -c Release -o /app/publish

# Publish do Blazor pode sair em publish/ ou publish/wwwroot
RUN mkdir -p /app/webroot && \
    if [ -f /app/publish/wwwroot/index.html ]; then cp -r /app/publish/wwwroot/. /app/webroot/; else cp -r /app/publish/. /app/webroot/; fi

# Servir com nginx (entrypoint criado aqui para evitar CRLF do Windows)
FROM nginx:alpine
RUN rm -rf /usr/share/nginx/html/*
COPY --from=build /app/webroot /usr/share/nginx/html
COPY --from=build /src/PeladeirosfcAppView/nginx.conf /etc/nginx/conf.d/default.conf
RUN echo '#!/bin/sh' > /entrypoint.sh && \
    echo 'set -e' >> /entrypoint.sh && \
    echo 'API_URL="${API_BASE_URL:-http://localhost:5112}"' >> /entrypoint.sh && \
    echo 'sed -i "s|__API_BASE_URL__|$API_URL|g" /usr/share/nginx/html/appsettings.json' >> /entrypoint.sh && \
    echo 'exec nginx -g "daemon off;"' >> /entrypoint.sh && \
    chmod +x /entrypoint.sh
EXPOSE 80
ENTRYPOINT ["/entrypoint.sh"]
