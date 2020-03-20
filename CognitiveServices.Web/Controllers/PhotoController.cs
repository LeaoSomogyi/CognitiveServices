using CognitiveServices.Web.Models;
using CognitiveServices.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CognitiveServices.Web.Controllers
{
    public class PhotoController : Controller
    {
        private readonly ICognitiveService _cognitiveService;

        public PhotoController(ICognitiveService cognitiveService)
        {
            _cognitiveService = cognitiveService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Detect(PhotoViewModel model)
        {
            if (model?.File == null)
            {
                TempData["photoError"] = "Para visualizar os detalhes da foto, é necessário escolhê-la primeiro.";

                return View(nameof(Index));
            }
            else
            {
                var restrictImage = await _cognitiveService.IsRestrictImageAsync(model);

                if (restrictImage)
                {
                    TempData["photoError"] = "Essa imagem possui conteúdo inapropriado (Adulto/Violência). " +
                        "Por favor, selecione outra imagem e tente novamente!";

                    return View(nameof(Index));
                }
                else
                {
                    var analyzeResult = await _cognitiveService.AnalyzeImageAsync(model);

                    return View(analyzeResult);
                }
            }
        }
    }
}