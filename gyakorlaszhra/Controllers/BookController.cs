using gyakorlaszhra.BookModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gyakorlaszhra.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/<BookController>
        [HttpGet]
        public IActionResult Get()
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            return Ok(context.Books.ToList());
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            var keresettKönyv = (from x in context.Books
                                where x.Id == id
                                select x).FirstOrDefault();
            if (keresettKönyv == null)
            {
                return NotFound($"Nincs #{id} azonosítóval vicc");
            }
            else
            {
                return Ok(keresettKönyv);
            }
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] Book ujKönyv)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            context.Books.Add(ujKönyv);
            context.SaveChanges();
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            FunnyDatabaseContext context = new FunnyDatabaseContext();
            var törlendőKönyv = (from x in context.Books
                                where x.Id == id
                                select x).FirstOrDefault();
            if(törlendőKönyv == null)
            {
                return NotFound("Nincs ilyen");
            }
            else
            {
                context.Remove(törlendőKönyv);

                context.SaveChanges();

                return Ok();

            }
        }
    }
}
