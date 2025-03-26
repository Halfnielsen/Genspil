namespace Genspil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Product p1 = new Product(10, "reperation", 200.0);

            Console.WriteLine($"Produkt detaljer {p1}");
            p1.sell();
            p1.editProduct(100.0, "på lager");
            Console.WriteLine($"{p1} er nu opdateret");
            p1.sell();
            Console.ReadLine(); 
        }
    }
}
