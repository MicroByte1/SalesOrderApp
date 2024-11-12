

using System.ComponentModel.DataAnnotations.Schema;

public class Contact
{
    public int Id { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    [ForeignKey("AppUser")]
    public int UserId { get; set; }
    public AppUser AppUser { get; set; }
}