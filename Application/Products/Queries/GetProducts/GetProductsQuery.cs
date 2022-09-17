using Application.Common.Dtos;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<List<ProductDto>> { }
    public class GetProductsQueryHandler :IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetProductsQueryHandler(IApplicationDbContext context,
                                       IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
           
            var list = await _context.Products
                .AsNoTracking()
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Name)
                .ToListAsync(cancellationToken);

            return list;
        }
    }
}
