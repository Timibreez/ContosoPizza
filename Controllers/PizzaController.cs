using Contosopizza.Models;
using Contosopizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace Contosopizza.Controllers;

[ApiController]
[Route("[controller]")]

public class PizzaController: ControllerBase{
    public PizzaController(){}

    //Get all Pizza in Memory
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        PizzaService.GetAll();
    
    // Get Pizza by Id
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id){
        var pizza = PizzaService.Get(id);

        if (pizza == null)
            return NotFound();
        
        return pizza;
    }

    // Add Pizza to Pizza List
    [HttpPost]
    public IActionResult Create(Pizza pizza){
        // saves new Pizza
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new {id = pizza.Id}, pizza);
    }

    // Update Pizza Information
    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza){
        if (id != pizza.Id)
            return BadRequest();
        
        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();
        
        PizzaService.Update(pizza);

        return NoContent();
    }

    // Delete Pizza from Memory
    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        var pizza = PizzaService.Get(id);
        if (pizza is null)
            return NotFound();
        
        PizzaService.Delete(id);

        return NoContent();
    }
}