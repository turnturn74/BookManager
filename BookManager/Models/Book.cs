namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Title must be filled.")]
        [StringLength(100, ErrorMessage = "Book Title cannot exceed more than 100 words.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "Descryption must be filled.")]
        [Display(Name = "Descryption")]
        public string Description { get; set; }

        [Key]
        [Column(Order = 3)]
        [Required(ErrorMessage = "Author's name must be filled.")]
        [StringLength(30, ErrorMessage = "Author's name cannot exceed more than 30 words.")]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        [Required(ErrorMessage = "Images must be filled.")]
        [Display(Name = "Images")]
        public string Images { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Price must be filled.")]
        [Range(1000, 1000000, ErrorMessage = "Price range must be around 1000 to 1000000")]
        [Display(Name = "Price")]
        public int Prices { get; set; }
    }
}
