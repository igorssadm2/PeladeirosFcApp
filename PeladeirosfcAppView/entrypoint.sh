#!/bin/sh
set -e
API_URL="${API_BASE_URL:-http://localhost:5112}"
sed -i "s|__API_BASE_URL__|$API_URL|g" /usr/share/nginx/html/appsettings.json
exec nginx -g "daemon off;"
