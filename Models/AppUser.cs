

using Microsoft.AspNetCore.Identity;

public class AppUser : IdentityUser<int>{ 
    public string Name { get; set; }

    public string Location { get; set; }

    public byte[] Picture { get; set; }

    public IEnumerable<Contact> Contacts { get; set; }

    public IEnumerable<Order> Orders { get; set; }
}