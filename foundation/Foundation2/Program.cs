using System;

class Program
{
    static void Main(string[] args)
    {

        Address address1 = new Address("Some Str", "Springfield", "MP", "SA");
        Address address2 = new Address("Another Str", "Springfield", "MP", "SA");

        Customer customer1 = new Customer("Paul Meck", address1);
        Customer customer2 = new Customer("Pediah Meck", address2);

        Product product1 = new Product("Laptop", "A123", 999.99, 1);
        Product product2 = new Product("Mouse", "B234", 25.50, 2);
        Product product3 = new Product("Keyboard", "C345", 45.00, 1);
        

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order1.GetTotalCost());

        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("Total Price: $" + order2.GetTotalCost());
    }
}
