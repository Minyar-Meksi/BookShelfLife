using System.ComponentModel.DataAnnotations;

namespace ShelfLife.Server.Data
{
    internal sealed class Book
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Genre { get; set; } = string.Empty;

        [Required]
        [Range(1800, 2024)]
        public int PublicationYear { get; set; } = 0;

        [Required]
        public int NumberOfPages { get; set; } = 0;

        [Required]
        public int NumberOfChapters { get; set; } = 0;

        public string CoverImage { get; set; } = string.Empty;

        public string Link { get; set; } = string.Empty;
    }
}
