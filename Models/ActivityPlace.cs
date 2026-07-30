using BeinHazmanimFinderAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeinHazmanimFinderAPI.Models;

public class ActivityPlace
{
    //[Required]
    public int Id { get; set; }

    [Required]
    [StringLength(70,
        ErrorMessage = "Invalid Name. It must be less then 70 nots")]
    public string Name { get; set; } = "";

    [Required]
    [StringLength(35,
        ErrorMessage = "Invalid category, It must be less then 35 nots")]
    [AllowedValues(
        [
        "Restaurant",
        "Water Park",
        "Nature Trail",
        "Museum",
        "Historical Site",
        "Adventure Park",
        "Boat Trip",
        "Visitor Center",
        "Children Activity"
        ],
        ErrorMessage = "Invalid category.")]
    public string Category { get; set; } = "";

    [Required]
    [StringLength(40,
        ErrorMessage = "Invalid City. It must be less then 40 nots")]
    public string City { get; set; } = "";

    [Required]
    [StringLength(50,
    ErrorMessage = "Invalid Area. It must be less then 50 nots")]
    public string Area { get; set; } = "";

    [Required]
    [StringLength(30,
        ErrorMessage = "Invalid Target Audience. It must be less then 30 nots")]
    [AllowedValues([
        "Families",
        "Children",
        "Youth",
        "Adults",
        "Men",
        "Women"
        ],
        ErrorMessage = "Invalid Target Audience")]
    public string TargetAudience { get; set; } = "";

    [Required]
    [Range(0, 1000,
        ErrorMessage = "Invalid price, it must be between 0 to 1000")]
    public decimal PricePerPerson { get; set; }

    [Required]
    [Range(0, 18,
        ErrorMessage = "Invalid minimum age. It must be 0 - 18")]
    public int MinimumAge { get; set; }

    [Required]
    public DateTime AvailableDate { get; set; }

    [Required]
    public bool IsAccessible { get; set; } = false;

    [Required]
    public bool RequiresKashrut { get; set; } = false;

    [StringLength(50,
        ErrorMessage = "Invalid Kashrut Authority. It must be less then 50 nots")]
    public string? KashrutAuthority { get; set; }
}
