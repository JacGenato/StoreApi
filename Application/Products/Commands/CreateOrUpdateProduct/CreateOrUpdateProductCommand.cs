using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Products.Commands.CreateOrUpdateProduct
{
    public class CreateOrUpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class CreateOrUpdateProductCommandHandler : IRequestHandler<CreateOrUpdateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateOrUpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrUpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == request.Id);

            if (product == null)
            {
                product = new Product
                {
                    Name = request.Name,
                    Description = request.Description
                };

               await  _context.Products.AddAsync(product, cancellationToken);

            }
            else
            {
                product.Name = request.Name;
                product.Description = request.Description;

                 _context.Products.Update(product);
            }
          
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
