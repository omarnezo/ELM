using ELM.Common.Dto;
using ELM.Infraa.IService;
using Microsoft.AspNetCore.Mvc;

namespace ELM.API.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] BookFilterDto bookFilterDto)
        {
            var books = await _bookService.GetBooks(bookFilterDto);
            return Ok(books);
        }
    }
}
