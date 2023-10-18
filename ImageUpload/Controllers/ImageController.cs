using ImageUpload.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;

        public ImageController(IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _environment = environment;
            _db = db;
        }
        public IActionResult Index()
        {
            var images = _db.Images.ToList();
            return View(images);
        }
        [HttpGet]
        public IActionResult FileUpload()
        {
            return View();
        }
        //    [HttpPost]
        //    public IActionResult FileUpload(FileUpload upload)
        //    {
        //        if (upload.FileName != null)
        //        {
        //            if (upload.MyFiles != null && upload.MyFiles.Count > 0)
        //            {

        //                foreach (var file in upload.MyFiles)
        //                {
        //                    if (file.Length > 0)
        //                    {
        //                        var fileName = file.FileName;
        //                        var fileExtension = Path.GetExtension(fileName);

        //                        var validationAttribute = new FileValidation(new string[] { ".jpg", ".jpeg", ".png", ".gif", ".pdf" }, 2 * 1024 * 1024);
        //                        var validationResult = validationAttribute.GetValidationResult(upload.MyFiles, new ValidationContext(upload));

        //                        if (validationResult != ValidationResult.Success)
        //                        {
        //                            ModelState.AddModelError("MyFiles", validationResult.ErrorMessage);
        //                            return View(upload);
        //                        }

        //                        // Saving to Folder
        //                        var imageFolder = Path.Combine(_environment.WebRootPath, "Image"); 
        //                        var imagePath = Path.Combine(imageFolder, fileName); 
        //                        using (var stream = new FileStream(imagePath, FileMode.Create))
        //                        {
        //                            file.CopyTo(stream);
        //                        }

        //                        // Save the image info to the database
        //                        var imageInfo = new ImageInfo
        //                        {
        //                            FileName = file.FileName,
        //                            FilePath = imagePath,
        //                        };

        //                        _db.Images.Add(imageInfo);
        //                        _db.SaveChanges();
        //                    }
        //                }
        //                TempData["success"] = "Image Uploaded Successfuly";
        //                ModelState.Clear();
        //                return RedirectToAction("Index");
        //            }
        //        }

        //        return View(upload);
        //    }

        //}


        [HttpPost]
        public IActionResult FileUpload([FromForm] FileUpload model)
        {
            if (ModelState.IsValid)
            {
                // Model is valid; proceed with processing the uploaded files.
                // The files will have already been validated by the custom attributes.

                // Example: Saving files
                // foreach (var file in model.Files)
                // {
                //     // Save or process the file here.
                // }

                return RedirectToAction("Success");
            }
            return View(model); // Return to the view with validation error messages.
        }
    }
}
