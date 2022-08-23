using AutoMapper;
using Lazhopee.Common.Enums;
using Lazhopee.Models.DTOs;
using Lazhopee.Models.Entities;

namespace Lazhopee.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // source -> destination
            // Product
            CreateMap<Product, ProductReadDTO>()
                .ForMember(destination => destination.StatusId, options => options.MapFrom(source => (int)source.Status))
                .ForMember(destination => destination.StatusDesc, options => options.MapFrom(source => ((ProductStatus)source.Status).ToString()));

            CreateMap<ProductCreationDTO, Product>();

            // Order Item
            CreateMap<OrderItem, OrderItemReadDTO>()
                .ForMember(destination => destination.ProductName, options => options.MapFrom(source => source.Product.ProductName))
                .ForMember(destination => destination.ProductStatusId, options => options.MapFrom(source => (int)source.Product.Status))
                .ForMember(destination => destination.ProductStatusDesc, options => options.MapFrom(source => ((ProductStatus)source.Product.Status).ToString()));

            CreateMap<OrderItemCreationDTO, OrderItem>();

            // Order
            CreateMap<Order, OrderReadDTO>()
                .ForMember(destination => destination.StatusId, options => options.MapFrom(source => (int)source.Status))
                .ForMember(destination => destination.StatusDesc, options => options.MapFrom(source => ((OrderStatus)source.Status).ToString()));

            CreateMap<OrderCreationDTO, Order>()
                .ForMember(destination => destination.Status, options => options.MapFrom(source => (int)OrderStatus.Pending));
        }
    }
}
