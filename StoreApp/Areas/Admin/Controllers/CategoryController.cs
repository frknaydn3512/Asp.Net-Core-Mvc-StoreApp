using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var categories = _manager.CategoryService.GetAllCategoriesWithProducts(false);
            return View(categories);
        }

        public IActionResult Create()
        {
            return View(new CategoryDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = new Category { CategoryName = categoryDto.CategoryName };
                _manager.CategoryService.CreateCategory(category);
                TempData["success"] = $"{categoryDto.CategoryName} has been created.";
                return RedirectToAction("Index");
            }
            return View(categoryDto);
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            var category = _manager.CategoryService.GetOneCategory(id, false);
            if (category is null)
                return NotFound();

            var dto = new CategoryDto { CategoryId = category.CategoryId, CategoryName = category.CategoryName };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    CategoryId = categoryDto.CategoryId,
                    CategoryName = categoryDto.CategoryName
                };
                _manager.CategoryService.UpdateOneCategory(category);
                TempData["success"] = $"{categoryDto.CategoryName} has been updated.";
                return RedirectToAction("Index");
            }
            return View(categoryDto);
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.CategoryService.DeleteOneCategory(id);
            TempData["danger"] = "The category has been removed.";
            return RedirectToAction("Index");
        }
    }
}