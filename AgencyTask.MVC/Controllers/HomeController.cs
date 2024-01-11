using AgencyTask.Business.Services.Interfaces;
using AgencyTask.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AgencyTask.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPortfolioService _service;

        public HomeController(IPortfolioService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Portfolio> entities = await _service.GetAllAsync();

            return View(entities);
        }
    }
}
