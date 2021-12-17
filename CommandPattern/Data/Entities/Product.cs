namespace CommandPattern.Data.Entities
{
    public class Product
    {
        public Product(string id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}