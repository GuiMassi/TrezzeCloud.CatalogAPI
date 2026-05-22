# TrezzeCloud.CatalogAPI

Microsserviço responsável pelo gerenciamento de jogos e fluxo de compra.

## Responsabilidades

- CRUD de jogos
- Biblioteca do usuário
- Fluxo de compra
- Publicação de OrderPlacedEvent
- Consumo de PaymentProcessedEvent

---

## Tecnologias

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

## Variáveis de Ambiente

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

## Seed de Biblioteca (UserLibrary)

O CatalogAPI possui seed fixo da UserLibrary usando um único usuário de teste com 5 jogos.

### Usuário Teste Compartilhado (UsersAPI)

- Id: aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
- Name: Usuario Teste
- Email: teste@trezzecloud.com

Esse usuário deve existir no UsersAPI com o mesmo Id para consistência entre microserviços.

### Segurança

- Os dados acima são para desenvolvimento/local.
- Não utilizar credenciais padrão em produção.

---

## Executar Localmente

```bash
dotnet restore
dotnet ef database update
dotnet run
```

---

## Docker

```bash
docker build -t trezzecloud-catalog-api .
```

---

## Kubernetes

Manifestos disponíveis em:

```txt
k8s/catalog-api
```

---
