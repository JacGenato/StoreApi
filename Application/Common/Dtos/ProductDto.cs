using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Dtos
{
    public class ProductDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<Product, ProductDto>()
        //        .ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority));
        //}
    }
}
