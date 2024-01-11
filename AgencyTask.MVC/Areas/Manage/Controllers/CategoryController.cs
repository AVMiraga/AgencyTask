using AgencyTask.Business.Services.Implementation;
using AgencyTask.Business.Services.Interfaces;
using AgencyTask.Business.ViewModels.CategoryVms;
using AgencyTask.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgencyTask.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories = await _categoryService.GetAllAsync();

            return View(categories);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryVm vm)
        {
            try
            {
                await _categoryService.CreateAsync(vm);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);

            UpdateCategoryVm updateCategoryVm = _mapper.Map<UpdateCategoryVm>(category);

            return View(updateCategoryVm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryVm vm)
        {
            try
            {
                await _categoryService.UpdateAsync(vm);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
