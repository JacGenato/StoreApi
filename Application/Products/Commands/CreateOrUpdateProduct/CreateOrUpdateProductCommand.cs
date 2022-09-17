using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Products.Commands.CreateOrUpdateProduct
{
    public class CreateOrUpdateProductCommand : IRequest<int>
    {
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
            var entity = new Product
            {
                Name = request.Name,
                Description = request.Description 
            };

         //   entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
