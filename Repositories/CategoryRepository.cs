using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public Category? GetOneCategory(int id, bool trackChanges)
        {
            return FindbyCondititon(c => c.CategoryId == id, trackChanges);
        }

        public IEnumerable<Category> GetAllCategoriesWithProducts(bool trackChanges)
        {
            return trackChanges
                ? _context.Categories.Include(c => c.Products).ToList()
                : _context.Categories.Include(c => c.Products).AsNoTracking().ToList();
        }
    }
}