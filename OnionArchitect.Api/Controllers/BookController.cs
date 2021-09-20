using Microsoft.AspNetCore.Mvc;
using OnionArchitect.Core.Domain;
using OnionArchitect.Core.Service.custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //custom service 
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //get
        [HttpGet]
        public async Task<IEnumerable<Book>> getall()
        {
            return await _bookService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Book> getall(int id)
        {
            return await _bookService.GetByIdAsync(id);
        }



        //post
        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            await _bookService.AddAsync(book);
            return Ok(book);
        }

        //[HttpPut]
        //public async Task<IActionResult> Post(int id, [FromBody] Book book)
        //{
        //    Book bookindb = await _bookService.GetByIdAsync(id);

        //    if (bookindb == null)
        //        return NotFound();


        //    await _bookService.EditAsync(book);


        //    return Ok(bookindb);
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            Book book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            await _bookService.RemoveAsync(book);
            return Ok();
        }
    }
}
