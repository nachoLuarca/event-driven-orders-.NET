# 🚀 Event-Driven Orders System (.NET + RabbitMQ + SQL Server)

Sistema de gestión de órdenes basado en arquitectura **Event-Driven**, utilizando **.NET 8, RabbitMQ, SQL Server y Docker**.

---

# 🧠 Descripción

Este proyecto implementa una arquitectura desacoplada donde una API REST publica eventos de órdenes a un broker de mensajería (RabbitMQ), y un Worker procesa dichas órdenes de forma asíncrona y las persiste en base de datos.

Simula un entorno real de sistemas distribuidos y microservicios, aplicando buenas prácticas de desarrollo backend moderno.

---

# 🏗️ Arquitectura del sistema

Cliente → Orders.Api → RabbitMQ → Orders.Worker → SQL Server

---

# 📦 Componentes

* **Orders.Api** → API REST que recibe y publica órdenes
* **Orders.Worker** → Servicio consumidor que procesa y guarda órdenes
* **RabbitMQ** → Broker de mensajería (cola de eventos)
* **SQL Server (Docker)** → Persistencia de datos
* **Orders.Domain** → Entidades del dominio
* **Orders.Application** → Lógica de negocio
* **Orders.Infrastructure** → Integración con RabbitMQ y EF Core

---

# 🔄 Flujo de funcionamiento

1. El cliente envía una orden a la API
2. La API publica el mensaje en RabbitMQ
3. RabbitMQ almacena el mensaje en la cola `orders`
4. El Worker consume el mensaje
5. La orden se procesa y se guarda en SQL Server
6. SQL Server genera automáticamente el ID

---

# 🛠️ Tecnologías utilizadas

* .NET 8
* C#
* ASP.NET Core Web API
* Entity Framework Core
* RabbitMQ
* SQL Server
* Docker
* Swagger (OpenAPI)

---

# ⚙️ Instalación y ejecución

## 1️⃣ Clonar repositorio

```bash
git clone https://github.com/nachoLuarca/event-driven-orders-.NET.git
cd event-driven-orders-.NET
```

---

## 2️⃣ Levantar servicios con Docker

```bash
docker-compose up -d
```

### 🔗 RabbitMQ Panel

http://localhost:15672

**Credenciales:**

* Usuario: guest
* Contraseña: guest

---

## 3️⃣ Ejecutar Worker (Consumer)

```bash
cd Orders.Worker
dotnet run
```

### ✔ Salida esperada:

```
🟢 Esperando órdenes...
```

---

## 4️⃣ Ejecutar API

```bash
cd Orders.Api
dotnet run
```

### 🔗 Swagger

http://localhost:5125/swagger

---

# 📬 Uso de la API

## Crear una orden

**POST** `/api/Orders`

```json
{
  "product": "Laptop",
  "price": 150000
}
```

⚠️ Nota:

* El `Id` **NO se envía**
* SQL Server lo genera automáticamente

---

# 🧪 Validación en base de datos

Puedes consultar las órdenes ejecutando:

```sql
SELECT * FROM Orders;
```

---

# 📌 Características principales

* Arquitectura desacoplada (Event-Driven)
* Comunicación asíncrona con RabbitMQ
* Persistencia en SQL Server con EF Core
* Inyección de dependencias (DI)
* Clean Architecture
* Escalabilidad horizontal (Workers)
* Uso de Docker para infraestructura

---

# 🧠 Conceptos aplicados

* Event-Driven Architecture
* Message Broker (RabbitMQ)
* Producer / Consumer pattern
* Clean Architecture
* Dependency Injection
* ORM con Entity Framework Core
* Sistemas distribuidos

---

# 🚀 Mejoras futuras

* Retry automático de mensajes
* Dead Letter Queue (DLQ)
* Logging estructurado (Serilog)
* Autenticación con JWT
* Dockerización completa (API + Worker + DB)
* Orquestación con Docker Compose avanzado
* Uso de Kubernetes (escenario avanzado)

---

# 👨‍💻 Autor

**Ignacio Luarca**
Desarrollador Full Stack .NET

---

# ⭐ Notas

Este proyecto fue desarrollado como práctica de arquitectura backend moderna, integrando mensajería, procesamiento asíncrono y persistencia de datos, siguiendo patrones utilizados en entornos empresariales.

---

# 🔥 Logros del proyecto

* ✔ Integración con SQL Server en Docker
* ✔ Persistencia real con Entity Framework Core
* ✔ Comunicación asincrónica con RabbitMQ
* ✔ Flujo completo Event-Driven funcional
* ✔ Implementación de Worker consumidor
* ✔ Debugging real de sistemas distribuidos
