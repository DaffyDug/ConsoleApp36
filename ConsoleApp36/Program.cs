using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {

    }
}

public interface Icomand
{
    public void Run();
}

class HomeManager
{
    public static readonly HomeManager homeManager;
    private HomeManager()
    {

    }
    static HomeManager()
    {
        homeManager = new HomeManager();
    }
    List<Icomand> icomands = new List<Icomand>()
    {
        new OnSun(),
        new OffSun(),
        new Onvacuum_cleaner(),
        new water_supply(),
        new Onsignaling(),
        new order_food()
    };
    public void RunComand<T>() where T : Icomand
    {
        foreach (var item in icomands)
        {
            if (item.GetType() == typeof(T))
            {
                item.Run();
                break;
            }
        }
    }
}
class OnSun : Icomand
{
    public void Run()
    {
        Console.WriteLine("свет включисля");
    }
}
class OffSun : Icomand
{
    public void Run()
    {
        Console.WriteLine("свет выключился");
    }
}
class Onvacuum_cleaner : Icomand
{
    public void Run()
    {
        Console.WriteLine("пылесос работает");
    }
}
class water_supply : Icomand
{
    public void Run()
    {
        Console.WriteLine("подача воды");
    }
}
class Onsignaling : Icomand
{
    public void Run()
    {
        Console.WriteLine("сигнализация включена");
    }
}
class order_food : Icomand
{
    public void Run()
    {
        Console.WriteLine("еда заказана");
    }
}




namespace Shop
{

    class Basket
    {
        public static readonly Basket basket;
        List<Product> products = new List<Product>();
        List<Product> products_Basket = new List<Product>();
        private Basket()
        {

        }
        static Basket()
        {
            basket = new Basket();
        }
        public void Add(Product product)
        {
            products.Add(product);
        }
        public void Remuve(Product product)
        {
            foreach (var item in products)
            {
                if (item.Name_Produrt == product.Name_Produrt)
                {
                    products.Remove(product);
                }
            }
            products.Remove(product);
        }
        public void Send(Product product)
        {
            products_Basket.Add(product);
        }

    }

    class Product
    {
        public string Name_Produrt { get; }
        private double Price;
        public Product(string name_product, double price)
        {
            Name_Produrt = name_product;
            Price = price;
        }
    }
    class AddProduct : Icomand
    {
        public void Run()
        {
            Basket.basket.Add(new Product("", 123));
        }
    }
    class RemoveProduct : Icomand
    {
        public void Run()
        {
            Basket.basket.Remuve(new Product("", 123));
        }
    }
    class SendProduct : Icomand
    {
        public void Run()
        {
            Basket.basket.Send(new Product("", 123));
        }
    }

}
