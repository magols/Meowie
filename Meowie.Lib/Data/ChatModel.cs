using System.ComponentModel.DataAnnotations;

namespace Meowie.Lib.Data
{
    public class ChatModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
    }

    public class ExampleModel
    {
        [Required]
        [StringLength(10, ErrorMessage = "Name is too long.")]
        public string? Name { get; set; }
    }
}
