using Microsoft.AspNetCore.Mvc;
using DauxChallenge.Services;
using DauxChallenge.Web.Models;

namespace DauxChallenge.Web.Controllers
{
    public class DauxController : Controller
    {
        private readonly IEncryptService _encryptService;

        public DauxController(IEncryptService encryptService)
        {
            _encryptService = encryptService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserInputModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string response = await _encryptService.EncryptApiAsync(model.Nombre, model.Apellido);

            ViewBag.Response = response;
            return View(model);
        }
    }
}
