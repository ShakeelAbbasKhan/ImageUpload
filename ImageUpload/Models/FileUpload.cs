using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ImageUpload.Models
{
    public class FileUpload
    {
        //[Required]
        //[DisplayName("File Name")]

        //public string FileName { get; set; }
        //[FileValidation(new string[] { ".jpg", ".png", ".jpeg" },2048,3)]
        //public List<IFormFile> MyFiles { get; set; }

        [MaxFileSize(10 * 1024 * 1024, ErrorMessage = "File size exceeds the limit.")]
        [MaxFileCount(5, ErrorMessage = "You can upload up to 5 files.")]
        [AllowedFileExtensions(new[] { ".jpg", ".png", ".gif" }, ErrorMessage = "Only .jpg, .png, and .gif files are allowed.")]
        public List<IFormFile> Files { get; set; }
    }
}

