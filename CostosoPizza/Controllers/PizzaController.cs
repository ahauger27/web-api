using CostosoPizza.Models;
using CostosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace CostosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PIzzaController : ControllerBase
{
    public PIzzaController()
    {
        
    }
    
    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id}, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();
        
        PizzaService.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delte(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }
}
