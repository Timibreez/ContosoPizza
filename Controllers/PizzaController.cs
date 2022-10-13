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
    
    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id){
        var pizza = PizzaService.Get(id);

        if (pizza == null)
            return NotFound();
        
        return pizza;
    }
}