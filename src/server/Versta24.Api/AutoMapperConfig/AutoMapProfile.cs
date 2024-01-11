using AutoMapper;
using Versta24.Api.Models;
using Versta24.Application.ModelDTOs;

namespace Versta24.Api.AutoMapperConfig;

public class AutoMapProfile: Profile
{
    public AutoMapProfile()
    {
        CreateMap<CreateOrderVm, CreateOrderDto>();
        CreateMap<OrderDto, OrderVm>();
    }
}