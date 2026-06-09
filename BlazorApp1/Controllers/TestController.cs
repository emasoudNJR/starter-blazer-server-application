using Microsoft.AspNetCore.Mvc;
using BlazorApp1.Services;

namespace BlazorApp1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _service;

    public OrdersController(OrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllOrdersAsync());
    }
}