.PHONY: up down

# Sobrescreva com COMPOSE=docker-compose se no seu Mac for o binário antigo
COMPOSE ?= docker compose

up:
	$(COMPOSE) up --build -d

down:
	$(COMPOSE) down
