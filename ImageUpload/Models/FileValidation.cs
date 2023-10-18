using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models
{
    public class FileValidation: ValidationAttribute
    {
        private readonly string[] _allowedExtensions;
        private readonly long _maxSizeInBytes;
        private readonly int _fileCount;

        public FileValidation(string[] allowedExtensions, long maxSizeInBytes, int fileCount)
        {
            _allowedExtensions = allowedExtensions;
            _maxSizeInBytes = maxSizeInBytes;
            _fileCount = fileCount;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var files = value as List<IFormFile>;

            //foreach (var file in files)
            //{

            //    if (file.Length > _maxSizeInBytes)
            //    {
            //        return new ValidationResult($"File size exceeds the maximum allowed size of {_maxSizeInBytes / 1024} KB.");
            //    }

            //    var fileExtension = Path.GetExtension(file.FileName);
            //    if (!_allowedExtensions.Contains(fileExtension.ToLower()))
            //    {
            //        return new ValidationResult($"Only {string.Join(", ", _allowedExtensions)} files are allowed.");
            //    }
            //}
            if (files.Count > _fileCount)
            {
                return new ValidationResult($"You can upload maximum {_fileCount} files.");
            }

            foreach (var file in files)
            {
                if (file != null)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (!_allowedExtensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult($"File Extension is not supported");
                    }
                }

                if (file != null)
                {
                    if (file.Length > (1000000 * _maxSizeInBytes))
                    {
                        return new ValidationResult($"The required size for file upload is {_maxSizeInBytes} MB.");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
