using System.ComponentModel.DataAnnotations;

namespace RentersNz.Models
{
    public enum PropertyType
    {
        Unit,
        Standalone,
        Other
    }

    public class Property
    {
        public int PropertyId { get; set; }
        public int LandlordId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address cannot exceed 100 characters")]
        public string Address { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string City { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Region cannot exceed 50 characters")]
        public string Region { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "PostalCode cannot exceed 10 characters")]
        public string PostalCode { get; set; }

        public PropertyType PropertyType { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Bedrooms must be between 1 and 10")]
        public int Bedrooms { get; set; }

        [Required]
        [Range(0.5, 5.0, ErrorMessage = "Bathrooms must be between 0.5 and 5.0")]
        public decimal Bathrooms { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Rent must be a positive value")]
        public decimal Rent { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Url)] // Optional validation for URLs
        public string ImageURLs { get; set; }
    }
}
