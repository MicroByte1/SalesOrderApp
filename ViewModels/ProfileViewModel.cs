

public class ProfileViewModel {
    public int Id { get; set; }

    public byte[] Picture = null;
    public int piclength { get; set; }

    public string Name { get; set; }

    public String Location { get; set; }

    public IEnumerable<Contact> Contacts { get; set; }

    public ProfileViewModel()
    {
        
    }

    public ProfileViewModel(AppUser user)
    {
        Id = user.Id;
        Name = user.Name;
        Location = user.Location;
        Picture = new byte[user.Picture.Length];
        piclength = user.Picture.Length;
        user.Picture.CopyTo(Picture, 0);
        Contacts = user.Contacts;
    }
}