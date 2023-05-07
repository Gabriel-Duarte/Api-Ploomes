using ApiPloomes.Application.Commands.Requests;
using ApiPloomes.Application.Commands.Responses;
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
		}
	}
}
