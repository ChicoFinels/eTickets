using eTickets.Data;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<Utilizador> userManager, SignInManager<Utilizador> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Filmes");
                    }
                }
                TempData["Error"] = "Credenciais incorretas. Por favor, tente novamente!";
                return View(loginVM);
            }

            TempData["Error"] = "Credenciais incorretas. Por favor, tente novamente!";
            return View(loginVM);
        }

        public IActionResult Registar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registar(RegistarVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "Este email já está a ser utilizado";
                return View(registerVM);
            }

            var newUser = new Utilizador()
            {
                Nome = registerVM.Nome,
                Email = registerVM.Email,
                UserName = registerVM.Email
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            return View("RegistarCompletado");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Filmes");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
