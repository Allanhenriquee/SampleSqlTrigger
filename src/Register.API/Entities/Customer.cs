namespace Register.API.Entities;

public class Customer
{
    public Customer(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.Now;
        Active = true;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool Active { get; set; }
}