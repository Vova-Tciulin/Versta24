using System.Data;
using AutoMapper;
using Versta24.Application.ModelDTOs;
using Versta24.Domain.Entities;

namespace Versta24.Application.AutoMapperConfig;

public class AutoMapProfile: Profile
{
    public AutoMapProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<CreateOrderDto, Order>();
    }
}