using ASPLAB_2.Data;
using ASPLAB_2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ASPLAB_2.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext dbUserContext;

        public UserController(UserContext dbUserContext)
        {
            this.dbUserContext = dbUserContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await dbUserContext.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(User user_)
        {
            await dbUserContext.AddAsync(user_);
            await dbUserContext.SaveChangesAsync();

            return RedirectToAction("Index", "User");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var user = await dbUserContext.Users.FindAsync(Id);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User user_)
        {
            var user = await dbUserContext.Users.FindAsync(user_.Id);

            if (user is not null)
            {
                user.Id = user_.Id;
                user.Name = user_.Name;
                user.Email = user_.Email;

                await dbUserContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "User");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(User user_)
        {
            var user = await dbUserContext.Users.FindAsync(user_.Id);

            if (user is not null)
            {
                dbUserContext.Users.Remove(user);

                await dbUserContext.SaveChangesAsync();
            }
            return RedirectToAction("Index", "User");
        }
    }
}
