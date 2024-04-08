using System.ComponentModel.DataAnnotations;

namespace RentersNz.Models
{
    public class Review
    {
        // Unique identifier for the review
        public int ReviewId { get; set; }

        // ID of the renter who posted the review
        public int RenterId { get; set; }

        // ID of the property being reviewed
        public int PropertyId { get; set; }

        // Rating given to the property, must be between 1 and 5
        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        // Optional text review
        public string ReviewText { get; set; }
    }
}
