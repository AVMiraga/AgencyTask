using AgencyTask.Business.Services.Interfaces;
using AgencyTask.Business.ViewModels.PortfolioVms;
using AgencyTask.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgencyTask.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public PortfolioController(IPortfolioService portfolioService, IMapper mapper, ICategoryService categoryService)
        {
            _portfolioService = portfolioService;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Portfolio> portfolios = await _portfolioService.GetAllAsync();

            return View(portfolios);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllAsync() ?? new List<Category>();

            ViewBag.Categories = categories;

            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePortfolioVm vm)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    var categories = await _categoryService.GetAllAsync() ?? new List<Category>();

                    ViewBag.Categories = categories;

                    return View(vm);
                }

                await _portfolioService.CreateAsync(vm);
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
            var categories = await _categoryService.GetAllAsync() ?? new List<Category>();

            ViewBag.Categories = categories;

            Portfolio portfolio = await _portfolioService.GetByIdAsync(id);

            UpdatePortfolioVm updatePortfolioVm = _mapper.Map<UpdatePortfolioVm>(portfolio);

            return View(updatePortfolioVm);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(UpdatePortfolioVm vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var categories = await _categoryService.GetAllAsync() ?? new List<Category>();

                    ViewBag.Categories = categories;

                    return View(vm);
                }

                await _portfolioService.UpdateAsync(vm);
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
                await _portfolioService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
