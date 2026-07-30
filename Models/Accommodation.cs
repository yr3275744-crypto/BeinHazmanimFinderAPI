using System;
using System.ComponentModel.DataAnnotations;

namespace BeinHazmanimFinderAPI.Models;

public class Accommodation
{
    //private readonly List<string> _validAccommodationType =
    //    ["Hotel",
    //    "Vacation Apartment",
    //    "Guest House",
    //    "Zimmer",
    //    "Resort",
    //    "Hostel"];
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(70,
        ErrorMessage = "Invalid Name. It must be less then 70 nots")]
    public string Name { get; set; } = "";

    [Required]
    [StringLength(30,
        ErrorMessage = "Invalid AccommodationType. " +
        "It must be less then 30 nots")]
    [AllowedValues(["Hotel",
        "Vacation Apartment",
        "Guest House",
        "Zimmer",
        "Resort",
        "Hostel"],
        ErrorMessage = "Invalid AccommodationType")]
    public string AccommodationType { get; set; } = "";

    [Required]
    [StringLength(40,
        ErrorMessage = "Invalid City. It must be less then 40 nots")]
    public string City { get; set; } = "";

    [Required]
    [StringLength(50,
    ErrorMessage = "Invalid Area. It must be less then 50 nots")]
    public string Area { get; set; } = "";

    [Required]
    [StringLength(50,
        ErrorMessage = "Invalid Kashrut Authority. " +
        "It must be less then 50 nots")]
    [AllowedValues(
        [
        "Eida Charedit",
        "Rav Rubin",
        "Rav Landau",
        "Badatz Mehadrin",
        "Local Kehillah"
        ],
        ErrorMessage = "Invalid Kashrut Authority.")]
    public string KashrutAuthority { get; set; } = "";

    [Required]
    [Range(0, 10000,
        ErrorMessage = "Invalid price. It must be bwtween 0 to 10000")]
    public decimal PricePerNight { get; set; }

    [Required]
    [Range(1, 500,
        ErrorMessage = "Invalid Maximum guesses. It must be between 1 to 500")]
    public int MaximumGuests { get; set; }

    [Required]
    public DateTime AvailableFrom { get; set; } = DateTime.UtcNow;

    [Required]
    public bool IsAccessible { get; set; } = false;

    [Required]
    public bool IsAbroad { get; set; } = false;


}