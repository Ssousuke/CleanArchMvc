using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.mappings;

public class DomainToDtoMappingProfile: Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}