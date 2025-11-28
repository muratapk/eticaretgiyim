using eticaretgiyim.Data;
using eticaretgiyim.Dto;
using eticaretgiyim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eticaretgiyim.Controllers
{
    public class RegisterController : Controller
    {
        private readonly GiyimDbContext _context;

        private readonly UserManager<AppUser> _userManager;
        public RegisterController(GiyimDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(appUserRegisterDto gelen)
        {
            Random rnd=new Random();
            int code=rnd.Next(100000,999999);
            AppUser user = new AppUser()
            {
                FirstName = gelen.FirstName,
                LastName = gelen.LastName,
                UserName = gelen.UserName,
                Email = gelen.Email,
                City = gelen.City,
                ConfirmCode =code,
            };
            var result=await _userManager.CreateAsync(user,gelen.Password);
            if(result.Succeeded)
            {
                //Kayıt başarılı ise yapılacak işlemler
                return RedirectToAction("Index","Home");
            }   
            return View();
        }
    }
}
