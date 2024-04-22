using ASPLAB_2.Data;
using ASPLAB_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPLAB_2.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderContext dbOrderContext;

        public OrderController(OrderContext dbOrderContext)
        {
            this.dbOrderContext = dbOrderContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await dbOrderContext.Orders.ToListAsync();
            return View(orders);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Order order_)
        {
            await dbOrderContext.AddAsync(order_);
            await dbOrderContext.SaveChangesAsync();

            return RedirectToAction("Index", "Order");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var order = await dbOrderContext.Orders.FindAsync(Id);
            return View(order);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Order order_)
        {
            var order = await dbOrderContext.Orders.FindAsync(order_.Id);

            if (order is not null)
            {
                order.Id = order_.Id;
                order.User = order_.User;
                order.ProductsCost = order_.ProductsCost;

                await dbOrderContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Order");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Order order_)
        {
            var order = await dbOrderContext.Orders.FindAsync(order_.Id);

            if (order is not null)
            {
                dbOrderContext.Orders.Remove(order);

                await dbOrderContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "Order");
        }
    }
}
