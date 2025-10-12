using Marten.Schema;

namespace Catalog.Api.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
    {
        new Product
        {
            Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "IPhone X",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-1.png",
            Price = 950.00M,
            Category = new List<string> { "Smart Phone" }
        },
        new Product
        {
            Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
            Name = "Samsung 10",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-2.png",
            Price = 840.00M,
            Category = new List<string> { "Smart Phone" }
        },
        new Product
        {
            Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
            Name = "Huawei Plus",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-3.png",
            Price = 650.00M,
            Category = new List<string> { "White Appliances" }
        },
        new Product
        {
            Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
            Name = "Xiaomi Mi 9",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-4.png",
            Price = 470.00M,
            Category = new List<string> { "White Appliances" }
        },
        new Product
        {
            Id = new Guid("b786103d-c621-4f5a-b498-23452610f88c"),
            Name = "HTC U11+ Plus",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-5.png",
            Price = 380.00M,
            Category = new List<string> { "Smart Phone" }
        },
        new Product
        {
            Id = new Guid("c4bbc4a2-4555-45d8-97cc-2a99b2167bff"),
            Name = "LG G7 ThinQ",
            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
            ImageFile = "product-6.png",
            Price = 240.00M,
            Category = new List<string> { "Home Kitchen" }
        },
        new Product
        {
            Id = new Guid("93170c85-7795-489c-8e8f-7dcf3b4f4188"),
            Name = "Panasonic Lumix",
            Description = "This camera is a professional-grade digital camera with advanced features for photography enthusiasts.",
            ImageFile = "product-7.png",
            Price = 240.00M,
            Category = new List<string> { "Camera" }
        },
        new Product
        {
            Id = new Guid("d5ab34c8-d8ce-4e69-94ee-ec1f875a9b35"),
            Name = "Canon EOS R5",
            Description = "Full-frame mirrorless camera with 45MP sensor and 8K video recording capability.",
            ImageFile = "product-8.png",
            Price = 3899.00M,
            Category = new List<string> { "Camera" }
        },
        new Product
        {
            Id = new Guid("e2b3e5c9-4f8a-45d3-8c5e-7a2b4e6f8d9a"),
            Name = "Sony PlayStation 5",
            Description = "Next-gen gaming console with ultra-high speed SSD and integrated I/O for a seamless gaming experience.",
            ImageFile = "product-9.png",
            Price = 499.00M,
            Category = new List<string> { "Electronics", "Gaming" }
        },
        new Product
        {
            Id = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"),
            Name = "MacBook Pro 16",
            Description = "Powerful laptop with M2 Pro chip, 16-inch Liquid Retina XDR display, and up to 22 hours of battery life.",
            ImageFile = "product-10.png",
            Price = 2499.00M,
            Category = new List<string> { "Computers", "Electronics" }
        },
        new Product
        {
            Id = new Guid("f9e8d7c6-b5a4-3210-fedc-ba0987654321"),
            Name = "Dell XPS 13",
            Description = "Ultra-portable laptop with InfinityEdge display and powerful performance in a compact design.",
            ImageFile = "product-11.png",
            Price = 1299.00M,
            Category = new List<string> { "Computers", "Electronics" }
        },
        new Product
        {
            Id = new Guid("12345678-90ab-cdef-1234-567890abcdef"),
            Name = "Samsung QLED 4K TV",
            Description = "65-inch QLED 4K Smart TV with Quantum HDR and Alexa built-in.",
            ImageFile = "product-12.png",
            Price = 1499.00M,
            Category = new List<string> { "Electronics", "Television" }
        }
    };
}
