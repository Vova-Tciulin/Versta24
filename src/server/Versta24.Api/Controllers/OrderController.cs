using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Versta24.Api.Models;
using Versta24.Application.ModelDTOs;
using Versta24.Application.Services;

namespace Versta24.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController: ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IMapper _map;
    private readonly IOrderService _orderService;

    public OrderController(ILogger<OrderController> logger, IMapper map, IOrderService orderService)
    {
        _logger = logger;
        _map = map;
        _orderService = orderService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetOrders()
    {
        _logger.LogInformation("Invoke GetOrder");

        var orders = await _orderService.GetOrdersAsync();
        var ordersVm = _map.Map<List<OrderVm>>(orders);
        
        _logger.LogInformation($"Return orders: {JsonSerializer.Serialize(ordersVm)}");
        
        return Ok(ordersVm);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetOrderById(Guid orderId)
    {
        _logger.LogInformation($"Invoke GetOrderById with id: {orderId}");

        var order = await _orderService.GetOrderByIdAsync(orderId);
        var orderVm = _map.Map<OrderVm>(order);
        
        _logger.LogInformation($"Return order: {JsonSerializer.Serialize(orderVm)}");
        
        return Ok(orderVm);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create([FromBody] CreateOrderVm model)
    {
        _logger.LogInformation($"Invoke CreateOrder with model: {JsonSerializer.Serialize(model)}");
        
        if (model.DateReceived<DateTime.Now)
        {
            _logger.LogWarning($"Not all fields in the model are filled in.");
            throw new ArgumentException("дата забора груза не может быть меньше текущей даты");
        }

        var modelDto = _map.Map<CreateOrderDto>(model);

        await _orderService.CreateOrderAsync(modelDto);
        
        return Ok();
    }
}