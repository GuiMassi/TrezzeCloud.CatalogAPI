# README - CatalogAPI

```md
# TrezzeCloud.CatalogAPI

Microsserviço responsável pelo gerenciamento de jogos e fluxo de compra.

## Responsabilidades

- CRUD de jogos
- Biblioteca do usuário
- Fluxo de compra
- Publicação de OrderPlacedEvent
- Consumo de PaymentProcessedEvent

---

# Tecnologias

- .NET 10
- ASP.NET Core
- Entity Framework Core
- SQL Server
- RabbitMQ
- MassTransit
- JWT
- Docker
- Kubernetes

---

# Variáveis de Ambiente

| Variável | Descrição |
|---|---|
| ConnectionStrings__CatalogDatabase | Connection string SQL Server |
| RabbitMq__Host | Host RabbitMQ |
| RabbitMq__Username | Usuário RabbitMQ |
| RabbitMq__Password | Senha RabbitMQ |
| Jwt__Issuer | Issuer JWT |
| Jwt__Audience | Audience JWT |
| Jwt__SecretKey | Secret JWT |

---

# Executar Localmente

```bash
dotnet restore
dotnet ef database update
dotnet run
````

---

# Docker

```bash
docker build -t trezzecloud-catalog-api .
```

---

# Kubernetes

Manifestos disponíveis em:

```txt
k8s/catalog-api
```

````

---
