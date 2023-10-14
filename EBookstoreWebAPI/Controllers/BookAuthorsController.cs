using BussinessObjects;
using Repositories.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Query;

[Route("api/[controller]")]
[ApiController]
public class BookAuthorsController : ControllerBase
{
    private UnitOfWork _unitOfWork = new UnitOfWork();
    public BookAuthorsController()
    {
        
    }

    // GET: api/BookAuthors
    [EnableQuery]
    [HttpGet]
    public IActionResult GetAll()
    {
        var list = _unitOfWork.BookAuthorRepository.Get();
        if (list == null)
        {
            return NotFound();
        }
        return Ok(list);
    }

    // GET: api/Authors/ById?Id=5
    [EnableQuery]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int bookId, int authorId)
    {
        var item = await _unitOfWork.BookAuthorRepository.GetByIDAsync(new object[bookId, authorId]);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }


    // PUT: api/Authors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [EnableQuery]
    [HttpPut("/book/{bookId}/author/{authorId}")]
    public async Task<IActionResult> Put(int bookId, int authorId, BookAuthor bookAuthor)
    {
        if (bookId != bookAuthor.BookId || authorId != bookAuthor.AuthorId)
        {
            return BadRequest();
        }

        try
        {
            _unitOfWork.BookAuthorRepository.Update(bookAuthor);
            await _unitOfWork.SaveAsync();

            if (!IsExists(bookId, authorId))
            {
                return NotFound();
            }
        }
        catch
        {
            return BadRequest();
        }

        return NoContent();
    }

    // POST: api/Authors
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<IActionResult> Post(BookAuthor bookAuthor)
    {

        try
        {
            await _unitOfWork.BookAuthorRepository.Insert(bookAuthor);
            await _unitOfWork.SaveAsync();
        }
        catch (DbUpdateException)
        {
            if (IsExists(bookAuthor.BookId, bookAuthor.AuthorId))
            {
                return Conflict();
            }
            else
            {
                throw;
            }
        }

        return CreatedAtAction("Post", new { bookId = bookAuthor.BookId, authorId = bookAuthor.AuthorId }, bookAuthor);
    }

    // DELETE: api/Authors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int bookId, int authorId)
    {
        var bookAuthor = await _unitOfWork.BookAuthorRepository.GetByIDAsync(new object[bookId, authorId]);

        if (bookAuthor == null)
        {
            return NotFound();
        }

        _unitOfWork.BookAuthorRepository.Delete(bookAuthor);
        await _unitOfWork.SaveAsync();

        return NoContent();
    }

    private bool IsExists(int bookId, int authorId)
    {
        var list = _unitOfWork.BookAuthorRepository.Get();
        return (list.ToList().Any(e => e.BookId == bookId && e.AuthorId == authorId));
    }
}