using System.ComponentModel.DataAnnotations;

namespace ImageUpload.Models
{
    public class ImageInfo
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }
    }
}
