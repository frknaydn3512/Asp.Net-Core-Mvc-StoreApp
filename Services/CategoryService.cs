using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryService(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

        public IEnumerable<Category> GetAllCategoriesWithProducts(bool trackChanges)
        {
            return _manager.Category.GetAllCategoriesWithProducts(trackChanges);
        }

        public Category? GetOneCategory(int id, bool trackChanges)
        {
            return _manager.Category.GetOneCategory(id, trackChanges);
        }

        public void CreateCategory(Category category)
        {
            _manager.Category.Create(category);
            _manager.Save();
        }

        public void UpdateOneCategory(Category category)
        {
            _manager.Category.Update(category);
            _manager.Save();
        }

        public void DeleteOneCategory(int id)
        {
            var category = _manager.Category.GetOneCategory(id, true);
            if (category is not null)
            {
                _manager.Category.Remove(category);
                _manager.Save();
            }
        }
    }
}