using Microsoft.AspNetCore.Mvc;
using OnionArchitect.Core.Domain;
using OnionArchitect.Core.Service.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IService<Author> _authorservice;

        public AuthorController(IService<Author> authorservice)
        {
            _authorservice = authorservice;
        }

        //get
        [HttpGet]
        public async Task<IEnumerable<Author>> getall()
        {
            return await _authorservice.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Author> getbyId(int id)
        {
            return await _authorservice.GetByIdAsync(id);
        }

        //post
        [HttpPost]
        public async Task<IActionResult> Post(Author author)
        {
            await _authorservice.AddAsync(author);
            return Ok(author);
        }

        //[HttpPut]
        //public async Task<IActionResult> put(int id, [FromBody] Author Auth)
        //{
        //    Author athindb = await _authorservice.GetByIdAsync(id);

        //    if (athindb == null)
        //        return NotFound();


        //    await _authorservice.EditAsync(Auth);


        //    return Ok(athindb);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          
            Author author = await _authorservice.GetByIdAsync(id);
            if (author == null)
                return NotFound();
            await _authorservice.RemoveAsync(author);
            return Ok();
        }




    }
}
