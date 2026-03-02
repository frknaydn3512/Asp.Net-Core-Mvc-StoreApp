using Entities.Models;
using Services.Contracts;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        IEnumerable<Category> GetAllCategoriesWithProducts(bool trackChanges);
        Category? GetOneCategory(int id, bool trackChanges);
        void CreateCategory(Category category);
        void UpdateOneCategory(Category category);
        void DeleteOneCategory(int id);
    }
}