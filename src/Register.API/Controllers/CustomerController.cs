using Bogus;
using Microsoft.AspNetCore.Mvc;
using Register.API.Data;
using Register.API.Entities;

namespace Register.API.Controllers;

[ApiController]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;
    
    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("customer-register")]
    public async Task<IActionResult> Post(string name)
    {
        var customer = new Customer(name);
        
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
        
        return Ok(customer);
    }
    
    [HttpPost("customer-fake-register")]
    public async Task<IActionResult> PostFake()
    {
        for (var i = 1; i <= 10; i++)
        {
            var faker = new Faker();
            
            var customer = new Customer(faker.Name.FirstName());
        
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            
        }

        return Ok();
    }

    [HttpPut("customer-change/{id:guid}")]
    public async Task<IActionResult> Put(Guid id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

        if (customer == null) return NotFound();

        var faker = new Faker();
        customer.Name = faker.Name.FirstName();
        
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("customer-delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

        if (customer == null) return NotFound();
        
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}