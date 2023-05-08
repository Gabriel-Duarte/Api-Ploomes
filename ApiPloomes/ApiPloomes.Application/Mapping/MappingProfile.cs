using ApiPloomes.Application.Commands.Requests;
using ApiPloomes.Application.Commands.Requests.CategoriesRequests;
using ApiPloomes.Application.Commands.Requests.ProductRequests;
using ApiPloomes.Application.Commands.Responses;
using ApiPloomes.Application.Commands.Responses.CategoriesResponses;
using ApiPloomes.Application.Commands.Responses.ProductsResponses;
using ApiPloomes.Application.Handlers;
using ApiPloomes.Application.Notifications;
using ApiPloomes.Domain.Entities;
using AutoMapper;

namespace ApiPloomes.Application.Mapping
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<GetProductResponse, Product>().ReverseMap();
			CreateMap<CreateProductResponse, Product>().ReverseMap();
			CreateMap<CreateProductRequest, Product>().ReverseMap();
			CreateMap<UpdateProductRequest, Product>().ReverseMap();
			CreateMap<UpdateProductResponse, Product>().ReverseMap();
			CreateMap<DeleteProductResponse, Product>().ReverseMap();
			CreateMap<ProductActionNotification, Product>().ReverseMap();
			CreateMap<GetProductByIdResponse, Product>().ReverseMap();

			CreateMap<GetCategoriesResponse, Category>().ReverseMap();
			CreateMap<CreateCategoryResponse, Category>().ReverseMap();
			CreateMap<CreateCategoryRequest, Category>().ReverseMap();
			CreateMap<UpdateCategoryResponse, Category>().ReverseMap();
			CreateMap<UpdateCategoryRequest, Category>().ReverseMap();
			CreateMap<DeleteCategoryResponse, Category>().ReverseMap();
			CreateMap<CategoriesActionNotification, Category>().ReverseMap();
			CreateMap<GetCategoriesProductsResponse, Category>().ReverseMap();
			CreateMap<GetCategoryByIdResponse, Category>().ReverseMap();

		}
	}
}
