using System;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.Repositories
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);

        Task<Product> GetByIdAsync(Guid id);
        Task SaveChangesAsync();
    }
}
