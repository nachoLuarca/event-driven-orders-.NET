# 🚀 Event-Driven Orders System

Sistema de gestión de órdenes basado en arquitectura **Event-Driven** utilizando **.NET 8**, **RabbitMQ** y **Docker**.

---

## 🧠 Descripción

Este proyecto implementa una arquitectura desacoplada donde una API REST publica eventos de órdenes a un broker de mensajería (**RabbitMQ**), y un Worker procesa dichas órdenes de forma asíncrona.

Simula un entorno real de sistemas distribuidos y microservicios, aplicando buenas prácticas de desarrollo backend moderno.

---

## 🏗️ Arquitectura del sistema

```
Cliente → Orders.Api → RabbitMQ → Orders.Worker
```

### 📦 Componentes

* **Orders.Api** → API REST que recibe y publica órdenes
* **Orders.Worker** → Servicio consumidor que procesa órdenes
* **RabbitMQ** → Broker de mensajería (cola de eventos)
* **Orders.Domain** → Entidades del dominio
* **Orders.Application** → Lógica de negocio
* **Orders.Infrastructure** → Integración con RabbitMQ

---

## 🔄 Flujo de funcionamiento

1. El cliente envía una orden a la API
2. La API publica el mensaje en RabbitMQ
3. RabbitMQ almacena el mensaje en la cola `orders`
4. El Worker consume el mensaje
5. La orden es procesada de forma asíncrona

---

## 🛠️ Tecnologías utilizadas

* .NET 8
* C#
* ASP.NET Core Web API
* RabbitMQ
* Docker
* Swagger (OpenAPI)

---

## ⚙️ Instalación y ejecución

### 1️⃣ Clonar repositorio

```bash
git clone https://github.com/nachoLuarca/event-driven-orders-.NET.git
cd event-driven-orders-.NET
```

---

### 2️⃣ Levantar RabbitMQ con Docker

```bash
docker-compose up -d
```

🔗 Panel de administración:
http://localhost:15672

Credenciales:

* Usuario: `guest`
* Contraseña: `guest`

---

### 3️⃣ Ejecutar Worker (Consumer)

```bash
cd Orders.Worker
dotnet run
```

Salida esperada:

```
🟢 Esperando órdenes...
```

---

### 4️⃣ Ejecutar API

```bash
cd Orders.Api
dotnet run
```

Swagger disponible en:

```
http://localhost:5125/swagger
```

---

## 📬 Uso de la API

### Crear una orden

**POST** `/api/Orders`

```json
{
  "id": "11111111-1111-1111-1111-111111111111",
  "product": "Laptop",
  "quantity": 1
}
```

---

## 📌 Características principales

* Arquitectura desacoplada (Event-Driven)
* Comunicación asíncrona mediante colas
* Escalabilidad horizontal (múltiples workers)
* Separación de responsabilidades (Clean Architecture)
* Uso de Docker para servicios externos
* Documentación con Swagger

---

## 🧠 Conceptos aplicados

* Event-Driven Architecture
* Message Broker (RabbitMQ)
* Producer / Consumer pattern
* Clean Architecture
* Microservices-ready design

---

## 🚀 Mejoras futuras

* Persistencia en base de datos (SQL Server o PostgreSQL)
* Implementación de reintentos automáticos
* Dead Letter Queue (DLQ)
* Logging estructurado
* Autenticación y autorización (JWT)
* Dockerización completa (API + Worker + DB)
* Orquestación con Docker Compose avanzado

---

## 👨‍💻 Autor

**Ignacio Luarca**
Desarrollador Full Stack .NET

---

## ⭐ Notas

Este proyecto fue desarrollado como práctica de arquitectura moderna backend, enfocado en el uso de mensajería y sistemas desacoplados, alineado con prácticas utilizadas en entornos empresariales.

---
