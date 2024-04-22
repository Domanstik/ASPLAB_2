using ASPLAB_2.Data;
using ASPLAB_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPLAB_2.Controllers
{
    public class StationeryController : Controller
    {
        private readonly StationeryContext dbStationeryContext;

        public StationeryController(StationeryContext dbStationeryContext)
        {
            this.dbStationeryContext = dbStationeryContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var stationeries = await dbStationeryContext.Stationeries.ToListAsync();
            return View(stationeries);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Stationery stationery_)
        {
            await dbStationeryContext.AddAsync(stationery_);
            await dbStationeryContext.SaveChangesAsync();

            return RedirectToAction("Index", "Stationery");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var stationery = await dbStationeryContext.Stationeries.FindAsync(Id);
            return View(stationery);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Stationery stationery_)
        {
            var stationery = await dbStationeryContext.Stationeries.FindAsync(stationery_.Id);

            if (stationery is not null)
            {
                stationery.Id = stationery_.Id;
                stationery.Name = stationery_.Name;
                stationery.Type = stationery_.Type;

                await dbStationeryContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Stationery");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Stationery stationery_)
        {
            var stationery = await dbStationeryContext.Stationeries.FindAsync(stationery_.Id);

            if (stationery is not null)
            {
                dbStationeryContext.Stationeries.Remove(stationery);

                await dbStationeryContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Stationery");
        }
    }
}
