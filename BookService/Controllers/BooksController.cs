using BookService.Models;
using BookService.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BookRepository _repository;

    // Конструктор с внедрением зависимости
    public BooksController(BookRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_repository.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var book = _repository.GetById(id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Book book)
    {
        _repository.Add(book);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Book book)
    {
        if (id != book.Id) return BadRequest();
        _repository.Update(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _repository.Delete(id);
        return NoContent();
    }
}