using CognitiveServices.Web.Models;
using CognitiveServices.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Controllers
{
    public class TextController : Controller
    {
        private ICognitiveService _cognitiveService;

        public TextController(ICognitiveService cognitiveService)
        {
            _cognitiveService = cognitiveService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Detect(TextViewModel model)
        {
            if (model?.Text == null)
            {
                TempData["textError"] = "É preciso informar uma palavra ou frase para ser analisada.";

                return View(nameof(Index));
            }
            else
            {
                var result = await _cognitiveService.AnalyzeTextAsync(model);

                return View(nameof(Detect), result);
            }
        }
    }
}