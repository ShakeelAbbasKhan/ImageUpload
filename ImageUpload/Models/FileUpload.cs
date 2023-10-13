using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ImageUpload.Models
{
    public class FileUpload
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        public List<IFormFile> MyFiles { get; set; }
        public List<string> MyFilePaths { get; set; }
    }
}
