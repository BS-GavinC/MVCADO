using Microsoft.AspNetCore.Mvc;
using MVCADO.Context;
using MVCADO.Models;

namespace MVCADO.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(IFormCollection form)
        {
            //Transforme le fichier en tableau de bytes
            IFormFile file = form.Files[0];
            Stream stream = file.OpenReadStream();
            byte[] content = new byte[stream.Length];
            stream.Read(content, 0, content.Length);

            string nomImage = Guid.NewGuid().ToString();

            string imageUrl = $"/wwwroot/image/{nomImage}.jpeg";

           

            System.IO.File.WriteAllBytes(Environment.CurrentDirectory + imageUrl, content);

            FakeDb.Urls.Add(imageUrl);

            return View();
        }
    }
}
