// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Drawing;
using System.Numerics;

List<Product> products = new List<Product>()
{
        new Product(name: "Nimbus 2000", price: 20.00M, sold: true, productTypeId: 1),
        new Product(name: "Wandz 1400", price: 10.99M, sold: false, productTypeId: 2),
        new Product(name: "Potions & More", price: 24.99M, sold: false, productTypeId: 3),
        new Product(name: "Basic Black Cauldron", price: 30.00M, sold: false, productTypeId: 4),
        new Product(name: "Quill & Ink Pack", price: 15.99M, sold: true, productTypeId: 5),
};

string greeting = @"Welcome to Reductio & Absurdum Magic Shop!
How can we help you today?";
Console.WriteLine(greeting);

string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Choose an option:
                        0. Exit
                        1. View All Products
                        2. Add Product
                        3. Update a Product
                        4. Delete Product");
    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Come back again soon");
    }
    else if (choice == "1")
    {
        ListAllProducts();
    }
    else if (choice == "2")
    {
        NewProduct();
    }
    else if (choice == "3")
    {
        UpdateProduct();
    }
    else if (choice == "4")
    {
        DeleteProduct();
    }
    else
    {
        Console.WriteLine("Invalid Choice. Try again!");
    }
}

Product chosenProduct = null;

if (choice != "0")
{
    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Try again! You missed something");
        }
    }
}

void ListAllProducts()
{
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(products[i])}");
    }
}

void ListAllAvailableProducts()
{
    var availableProducts = products.Where(product => !product.Sold).ToList();

    for (int i = 0; i < availableProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {ProductDetails(availableProducts[i])}");
    }
}


void NewProduct()
{
    Console.WriteLine("Enter the details for the new product:");
    Console.WriteLine("Name: ");
    string? name = Console.ReadLine().Trim();

    Console.WriteLine("Asking Price: ");
    decimal price;
    while (!decimal.TryParse(Console.ReadLine().Trim(), out price));

    Console.WriteLine("Category: ");
    int productTypeId;
    while (!int.TryParse(Console.ReadLine().Trim(), out productTypeId));


    Product newProduct = new Product(name, price, sold: false, productTypeId);
    products.Add(newProduct);

    Console.WriteLine($"The product {newProduct.Name} has been added!");
}

void UpdateProduct()
{
    ListAllAvailableProducts();
    Console.WriteLine("Please select a product to update:");
    int chosenIndex;
    while (!int.TryParse(Console.ReadLine().Trim(), out chosenIndex));

    var availableProducts = products.Where(product => !product.Sold).ToList();

    if (chosenIndex >= 1 && chosenIndex <= availableProducts.Count)
    {
        int selectedIndex = chosenIndex - 1;
        var selectedProduct = availableProducts[selectedIndex];

        Console.WriteLine($"Updating product: {selectedProduct.Name}");

        Console.WriteLine("Enter new name (or press Enter to keep current):");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            selectedProduct.Name = newName;
        }

        Console.WriteLine("Enter new price (or press Enter to keep current):");
        decimal newPrice;
        if (decimal.TryParse(Console.ReadLine().Trim(), out newPrice))
        {
            selectedProduct.Price = newPrice;
        }

        Console.WriteLine("Enter new product type ID (or press Enter to keep current):");
        int newProductTypeId;

        if (int.TryParse(Console.ReadLine().Trim(), out newProductTypeId))
        {
            selectedProduct.ProductTypeId = newProductTypeId;
        }

        Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Invalid selection. Please choose a valid product number.");
        }
}


void DeleteProduct()
{
    ListAllAvailableProducts();
    Console.WriteLine("Please enter product number to delete:");
    int chosenIndex;
    while (!int.TryParse(Console.ReadLine().Trim(), out chosenIndex)) ;
}


string ProductDetails(Product product)
{
    string availability = product.Sold ? "not available" : "available";
    return $"{product.Name} is ${product.Price} while belonging to category {product.ProductTypeId} and is {availability}.";
}