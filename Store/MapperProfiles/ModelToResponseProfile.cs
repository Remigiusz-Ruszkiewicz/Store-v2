using AutoMapper;
using Store.Contracts.V1.Responses;
using Store.Models;

namespace Store.MapperProfiles
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.CategoryName, x => x.MapFrom(src => src.Category.Name));

            CreateMap<Category, CategoryResponse>();
            CreateMap<Basket, BasketResponse>()
                .ForMember(dest=>dest.ProductName,x=>x.MapFrom(src=>src.Product.Name))
                .ForMember(dest=>dest.Summary,x=>x.MapFrom(src=>src.Quantity*src.Product.Price))
                .ForMember(dest=>dest.Price,x=>x.MapFrom(src=>src.Product.Price));

        }
    }
}
