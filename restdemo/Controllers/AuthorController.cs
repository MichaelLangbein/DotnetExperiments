using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {

        private readonly Repository _ar;
        public AuthorController(Repository ar)
        {
            _ar = ar;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _ar.GetAuthors();
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public Author Get(int id)
        {
            return _ar.GetAuthor(id);
        }

        // POST api/<AuthorController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateAuthorDto author)
        {
            var savedAuthor = _ar.CreateAuthor(author);
            return CreatedAtAction(nameof(Get), new { id = savedAuthor.Id }, savedAuthor);
        }


        // // DELETE api/<AuthorController>/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
