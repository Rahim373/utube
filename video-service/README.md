# Video Service

[![Build video-service on Pull Request and Push](https://github.com/Rahim373/utube/actions/workflows/video-service.build-on-pr-and-push.yml/badge.svg)](https://github.com/Rahim373/utube/actions/workflows/video-service.build-on-pr-and-push.yml)

## :hammer_and_wrench: Environment variables

These settings can be set in the `appsettings.json` file or can be overridden using environment variable.

| Variable name | Usage | Example |
| -------------- | ----- | ------- |
| `RabbitMQSetting__Endpoint` | RabbitMQ Endpoint | `localhost:15674` |
| `RabbitMQSetting__Username` | Username | `guest` |
| `RabbitMQSetting__Password` | Passord | `pass***d` |
| `RabbitMQSetting__VirtualHost` | Virtual host name, default `'/'` | `my-host` |

## :speech_balloon: Rest API Endpoints

## :dash: gRPC Endpoints

## 	:loudspeaker: Events
| Event Name | Type | Purpose |
| ---------- | ----- | ------- |