using System;

public class ProductTypeId
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ProductTypeId(int id, string name)
    {
         Id = id;
         Name = name;
    }
}
