// See https://aka.ms/new-console-template for more information
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
}