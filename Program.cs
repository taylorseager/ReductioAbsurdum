// See https://aka.ms/new-console-template for more information

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
        //UpdateProduct();
    }
    else if (choice == "4")
    {
        //DeleteProduct();
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
    foreach (var product in products)
    {
        Console.WriteLine($"{ProductDetails(product)}");
    }
}

void NewProduct()
{
    Console.WriteLine("Enter the details for the new product:");
    Console.WriteLine("Name: ");
    string? name = Console.ReadLine().Trim();

    Console.WriteLine("Asking Price: ");
    decimal price;
    while (!decimal.TryParse(Console.ReadLine().Trim(), out price)) ;

    Console.WriteLine("Category: ");
    int productTypeId;
    while (!int.TryParse(Console.ReadLine().Trim(), out productTypeId)) ;


    Product newProduct = new Product(name, price, sold: false, productTypeId);
    products.Add(newProduct);

    Console.WriteLine($"The product {newProduct.Name} has been added!");
}

//void UpdateProduct()
//{

//}

//void DeleteProduct()
//{

//}


string ProductDetails(Product product)
{
    string availability = product.Sold ? "not available" : "available";
    return $"{product.Name} is ${product.Price} while belonging to category {product.ProductTypeId} and is {availability}.";
}