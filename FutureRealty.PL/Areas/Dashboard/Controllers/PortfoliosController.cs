using AutoMapper;
using FutureRealty.DAL.Data;
using FutureRealty.DAL.Models;
using FutureRealty.PL.Areas.Dashboard.ViewModels;
using FutureRealty.PL.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FutureRealty.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PortfoliosController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PortfoliosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            
            return View(mapper.Map<IEnumerable<PortfoliosVM>>(context.Portfolios.ToList()));

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(PortfolioFormVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
           

            var Portfolio = mapper.Map<Portfolio>(vm);
            context.Add(Portfolio);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public IActionResult Details(int id)
        {
      
            var Portfolio = context.Portfolios.Find(id);


            if (Portfolio == null)
            {
                return NotFound();
            }

            return View(mapper.Map<PortfolioDetailsVM>(Portfolio));
        }
        public IActionResult Delete(int id)
        {
            var Portfolio = context.Portfolios.Find(id);
            if (Portfolio is null)
            {
                return NotFound();
            }

            return View(mapper.Map<PortfoliosVM>(Portfolio));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var Portfolio = context.Portfolios.Find(id);
            if (Portfolio is null)
            {
                return RedirectToAction(nameof(Index));
            }
           
            context.Portfolios.Remove(Portfolio);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var Portfolio = context.Portfolios.Find(id);
            if (Portfolio is null)
            {
                return NotFound();
            }

            var PortfolioVm = mapper.Map<PortfolioFormVM>(Portfolio);

            return View(PortfolioVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PortfolioFormVM vm)
        {
            var Portfolio = context.Portfolios.Find(vm.Id);
            if (Portfolio is null)
            {
                return NotFound();
            }


            if (!ModelState.IsValid)
            {
                return View(vm);
            }

        

            mapper.Map(vm, Portfolio);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



    }
}