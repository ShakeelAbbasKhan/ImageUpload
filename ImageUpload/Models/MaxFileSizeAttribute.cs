using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxSize;

        public MaxFileSizeAttribute(long maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is List<IFormFile> files)
            {
                foreach (var file in files)
                {
                    if (file.Length > _maxSize)
                    {
                        return new ValidationResult($"File '{file.FileName}' exceeds the maximum allowed size of {_maxSize} bytes.");
                    }
                }
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid parameter type. Expected a list of IFormFile.");
        }
    }
}
