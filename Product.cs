using System;

	public class Product
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public bool Sold { get; set; }
		public int ProductTypeId { get; set; }

        public Product(string name, decimal price, bool sold, int productTypeId)
        {
            Name = name;
            Price = price;
            Sold = sold;
            ProductTypeId = productTypeId;
        }
    }

