using Microsoft.AspNetCore.Mvc;
using Orders.Domain;
using Orders.Infrastructure;

namespace Orders.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(Order order)
    {
        var publisher = new RabbitMQPublisher();
        publisher.Publish(order);

        return Ok("Orden enviada correctamente");
    }
}   