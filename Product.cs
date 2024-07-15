using System;

	public class Product
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public bool Sold { get; set; }
		public int ProductTypeId { get; set; }
        public DateTime DateStocked { get; set; }

    public Product(string name, decimal price, bool sold, int productTypeId, DateTime dateStocked)
        {
            Name = name;
            Price = price;
            Sold = sold;
            ProductTypeId = productTypeId;
        DateStocked = dateStocked;
        }
    }

