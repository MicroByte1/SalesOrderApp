

using System.ComponentModel.DataAnnotations;

public class RegisterViewModel {
    [Required]
    public string UserName { get; set; }
    [Required]
    public String Password { get; set; }
    [Required]
    [Display(Name="Address")]
    public string Location { get; set; }
    [Required]
    public string Name { get; set; }

    public string  Email { get; set; }
}