using ImageUpload.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public ImageController(IWebHostEnvironment _environment)
        {
            environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FileUpload(FileUpload upload)
        {
            if (upload != null)
            {
                if (upload.MyFiles != null && upload.MyFiles.Count > 0)
                {

                    foreach (var file in upload.MyFiles)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = file.FileName;
                            var fileExtension = Path.GetExtension(fileName);

                            var validationAttribute = new FileValidation(new string[] { ".jpg", ".jpeg", ".png", ".gif", ".pdf" }, 2 * 1024 * 1024);
                            var validationResult = validationAttribute.GetValidationResult(upload.MyFiles, new ValidationContext(upload));

                            if (validationResult != ValidationResult.Success)
                            {
                                ModelState.AddModelError("Files", validationResult.ErrorMessage);
                                return View(upload);
                            }


                            // Saving to Folder
                            var JMMFilePath = Path.Combine(environment.WebRootPath, "Image", Guid.NewGuid() + Path.GetExtension(file.FileName));
                            using (var stream = new FileStream(JMMFilePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }
                        }
                    }
                    ViewBag.ResultMessage = "Files Added Successfully";
                    ModelState.Clear();
                    return View();
                }
            }

            return View(upload);
        }

    }
}
