using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CretaceousApi.Models;

namespace CretaceousApi.Controllers
{
  [Route("api/[controller]")] //stating api infront of controller. controller actions are async so they can scale to handle more requests. 
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly CretaceousApiContext _db;

    public AnimalsController(CretaceousApiContext db)
    {
      _db = db;
    }

    // GET: api/Animals
    [HttpGet]
    public async Task<ActionResult<PaginatedList<Animal>>> Get(string species, string name, int minimumAge, int pageIndex = 1, int pageSize = 10) //take in multiple parameters
    {
      IQueryable<Animal> query = _db.Animals.AsQueryable(); //gets us ready to do a search

      if (species != null) //if species is not nothing...
      {
        query = query.Where(entry => entry.Species == species); //find the query of all of the entries that match the species that we entered.
      }
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (minimumAge > 0)
      {
        query = query.Where(entry => entry.Age >= minimumAge);
      }

      var paginatedAnimals = await PaginatedList<Animal>.CreateAsync(query, pageIndex, pageSize);

      if (paginatedAnimals.Count == 0)
      {
        return NotFound();
      }

      return paginatedAnimals;

    }
    //return a list of animals from a datbase. Also returns status code 

    // GET: api/Animals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      return animal; //return specific animal based on what we found. Also returns status code.
    }

    // POST api/animals
    [HttpPost] //post request to create a new animal
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal); // GetAnimal states the controller name, second argument creates a new animal id, third argument is the resource variable name that was created by this action.
    }

    // PUT: api/Animals/5
    [HttpPut("{id}")] //PUT action just edits
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId) //check that the id is the id for the animal we passed through
      {
        return BadRequest(); //if invalid send bad request
      }

      _db.Animals.Update(animal); //if it is valid update the animal in the database

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException) //if an error is thrown by the database...
      {
        if (!AnimalExists(id)) //check to see if an animal in the database does not exist
        {
          return NotFound(); //if it doesnt, then not found
        }
        else
        {
          throw; //throw an error?
        }
      }

      return NoContent();
    }

    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }

    // DELETE: api/Animals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}
