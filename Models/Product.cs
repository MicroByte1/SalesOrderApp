


public class Product {
    public int Id { get; set; }
    // qr code
    public string Number { get; set; }
    public string Name { get; set; }

    public decimal Price { get; set; }

    public byte[] Img { get; set; }

    public ProductType Type { get; set; }


}