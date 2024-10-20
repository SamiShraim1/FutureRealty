using AutoMapper;
using FutureRealty.DAL.Data;
using FutureRealty.DAL.Models;
using FutureRealty.PL.Areas.Dashboard.ViewModels;
using FutureRealty.PL.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FutureRealty.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ItemsController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            
            return View(mapper.Map<IEnumerable<ItemsVM>>(context.Items.ToList()));

        }
        [HttpGet]
        public IActionResult Create()
        {
            var portfolios = context.Portfolios.ToList();
            var vm = new ItemformVM
            {
                Portfolios = new SelectList(portfolios, "Id", "Name")
            };

            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ItemformVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
           

            var Item = mapper.Map<Item>(vm);
            context.Add(Item);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));


        }
        //[HttpGet]
        //public IActionResult Details(int id)
        //{
      
        //    var Portfolio = context.Portfolios.Find(id);


        //    if (Portfolio == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(mapper.Map<PortfolioDetailsVM>(Portfolio));
        //}
        //public IActionResult Delete(int id)
        //{
        //    var Portfolio = context.Portfolios.Find(id);
        //    if (Portfolio is null)
        //    {
        //        return NotFound();
        //    }

        //    return View(mapper.Map<PortfoliosVM>(Portfolio));
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    var Portfolio = context.Portfolios.Find(id);
        //    if (Portfolio is null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
           
        //    context.Portfolios.Remove(Portfolio);
        //    context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //public IActionResult Edit(int id)
        //{
        //    var Portfolio = context.Portfolios.Find(id);
        //    if (Portfolio is null)
        //    {
        //        return NotFound();
        //    }

        //    var PortfolioVm = mapper.Map<PortfolioFormVM>(Portfolio);

        //    return View(PortfolioVm);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(PortfolioFormVM vm)
        //{
        //    var Portfolio = context.Portfolios.Find(vm.Id);
        //    if (Portfolio is null)
        //    {
        //        return NotFound();
        //    }


        //    if (!ModelState.IsValid)
        //    {
        //        return View(vm);
        //    }

        

        //    mapper.Map(vm, Portfolio);
        //    context.SaveChanges();

        //    return RedirectToAction(nameof(Index));
        //}



    }
}