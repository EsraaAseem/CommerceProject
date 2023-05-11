using AspCoreCommerce.Model;
using AspCoreCommerce.Model.ViewModel;
using AspCorePartCommerce.DataAccess.afterMapper;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCorePartCommerce.DataAccess.autoMapper
{
    public class autoMapperProf:Profile
    {
        public autoMapperProf()
        {

          CreateMap<Category, CategoryView>().ReverseMap();
            CreateMap<CategoryRequest, Category>().ReverseMap();
           CreateMap<CategoryRequest, Category>().AfterMap<AddMappingProfile>();
            CreateMap<Brand, BrandView>().ReverseMap();
            CreateMap<BrandRequest, Brand>().ReverseMap();
            CreateMap<BrandRequest, Brand>().AfterMap<AddMappingBrandProfile>();
            //CreateMap<Product, ProductView>().ReverseMap();
           // CreateMap<Product, ProductView>().ForMember(d => d.category).ForMember(d => d.brand);
            CreateMap<Product, ProductView>();
            CreateMap<ProductRequest, Product>().ReverseMap();
            CreateMap<ProductRequest, Product>().AfterMap<AddMappingProductProfile>();
            CreateMap<shoppingCartEdit, ShoppingCart>().AfterMap<AddMappingShoppingProfile>();

            CreateMap<ShoppingCart,shoppingCartrequest>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartView>().ReverseMap();

            CreateMap<ApplicationUser, AddressDto>().ReverseMap();
            CreateMap<AddressDto, ApplicationUser>().ReverseMap();
            CreateMap<DelivaryMethod, Delievery>();
            CreateMap<Delievery, DelivaryMethod>().ReverseMap();
            CreateMap<AddressDto, Address>();
            CreateMap<Orders, orderToReturnDto>()
                .ForMember(d=>d.DelivaryMethod, o=>o.MapFrom(s=>s.DelivaryMethod.shortTime))
                .ForMember(d => d.DelivaryMethod, o => o.MapFrom(s => s.DelivaryMethod.Price));
            CreateMap<Orders, orderToReturnDto>()
                .ForMember(d => d.DelivaryMethod, o => o.MapFrom(s => s.DelivaryMethod.shortTime))
                .ForMember(d => d.DelivaryMethod, o => o.MapFrom(s => s.DelivaryMethod.Price))
                .ForMember(d => d.Total, o => o.MapFrom(s => s.GetTotal()));

            CreateMap<orderItems, orderItemDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
                .ForMember(d => d.title, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.ImageUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
                ;


        }
    }
}
