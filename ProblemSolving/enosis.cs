using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CodingPractice
{
    

    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Balance { get; set; }
        List<(IProduct product, int quantity)> Orders { get; set; }
    }

    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        decimal ShippingCost { get; set; }
    }

    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal ShippingCost { get; set; }

        // Constructor
        public Product(int id, string name, decimal price, decimal shippingCost)
        {
            Id = id;
            Name = name;
            Price = price;
            ShippingCost = shippingCost;
        }
    }
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<(IProduct product, int quantity)> Orders { get; set; }

        // Constructor
        public User(int id, string name, decimal balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
            Orders = new List<(IProduct product, int quantity)>();
        }
    }

    public interface ICompany
    {
        List<IUser> Users { get; set; }
        List<(IProduct product, int quantity)> Products { get; set; }
        void AddProduct(IProduct product, int quantity);
        void AddUser(IUser user);
        void MakeOrder(List<(IProduct product, int quantity)> products, IUser user);
    }
    public class Company : ICompany
    {
        public List<IUser> Users { get; set; }
        public List<(IProduct product, int quantity)> Products { get; set; }

        // Constructor
        public Company()
        {
            Users = new List<IUser>();
            Products = new List<(IProduct product, int quantity)>();
        }

        // Implementing the MakeOrder method
        public void MakeOrder(List<(IProduct product, int quantity)> products, IUser user)
        {
            // Check if products are available and user exists
            //Products.Where(x=>x.)

            if(products.All(p=>Products.Any(ep=>ep.product.Id == p.product.Id)) && Users.Any(u=>u.Id ==  user.Id))
         
            if (products.All(p => Products.Any(existingProduct => existingProduct.product.Id == p.product.Id) && Users.Contains(user)))
            
            {
                
                decimal highestShippingCost = products.Max(p => p.product.ShippingCost);
                decimal productCost = 0;

                foreach (var product in products)
                {
                    productCost += product.quantity * product.product.Price;
                }

                decimal totalCost1 = products.Sum(p => p.product.Price * p.quantity) + highestShippingCost;
                decimal totalCost = productCost + highestShippingCost;

              
                if (user.Balance >= totalCost)
                {
                    
                    user.Balance -= totalCost;

                    
                    foreach (var order in products)
                    {
                        var productIndex = Products.FindIndex(p => p.product == order.product);
                        var product = Products.Find(p => p.product.Id == order.product.Id);
                        var productInInventory = Products.FirstOrDefault(p => p.product == order.product);

                        if (productInInventory.product != null && productInInventory.quantity>=order.quantity)
                        {
                                productInInventory.quantity -= order.quantity;
                            Products[productIndex] = (order.product, productInInventory.quantity - order.quantity);
                        }

                        
                        if (productIndex != -1)
                        {
                            Products[productIndex] = (order.product, Products[productIndex].quantity - order.quantity);
                        }
                    }

                   
                    user.Orders.AddRange(products);

                    Console.WriteLine("Order successful!");
                }
                else
                {
                    Console.WriteLine("Insufficient funds for the order.");
                }
            }
            else
            {
                Console.WriteLine("Invalid products or user.");
            }
        }

        // Implementing the AddProduct method
        public void AddProduct(IProduct product, int quantity)
        {
            var existingProduct = Products.Find(p => p.product == product);

            if (existingProduct.product != default)
            {
                // Product exists, increase quantity on hand
                existingProduct.quantity += quantity;
                //var index = Products.IndexOf(existingProduct);
                //Products[index] = (existingProduct.product, existingProduct.quantity + quantity);
            }
            else
            {
                // Product does not exist, add to the list
                Products.Add((product, quantity));
            }
        }

        // Implementing the AddUser method
        public void AddUser(IUser user)
        {
            Users.Add(user);
        }
    }

}
