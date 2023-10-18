using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models
{
    public class MaxFileCountAttribute : ValidationAttribute
    {
        private readonly int _maxCount;

        public MaxFileCountAttribute(int maxCount)
        {
            _maxCount = maxCount;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is List<IFormFile> files)
            {
                if (files.Count > _maxCount)
                {
                    return new ValidationResult($"The maximum allowed file count is {_maxCount}.");
                }
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid parameter type. Expected a list of IFormFile.");
        }

    }
}
