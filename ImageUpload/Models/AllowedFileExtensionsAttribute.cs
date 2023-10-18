using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models
{
    public class AllowedFileExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;

        public AllowedFileExtensionsAttribute(string[] allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is List<IFormFile> files)
            {
                foreach (var file in files)
                {
                    var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                    if (!_allowedExtensions.Contains(fileExtension))
                    {
                        return new ValidationResult($"File '{file.FileName}' has an invalid file extension.");
                    }
                }
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid parameter type. Expected a list of IFormFile.");
        }
    }
}
